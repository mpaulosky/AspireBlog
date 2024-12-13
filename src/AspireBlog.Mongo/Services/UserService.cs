using Ardalis.GuardClauses;

using AspireBlog.Common.Entities;
using AspireBlog.Common.GuardClauses;
using AspireBlog.Common.Interfaces;
using AspireBlog.Common.Mappers;
using AspireBlog.Common.Models;
using AspireBlog.Mongo.Repositories;

using Microsoft.Extensions.Logging;

using MongoDB.Bson;

namespace AspireBlog.Mongo.Services;

public class UserService : IUserService
{
	private readonly ILogger<UserService> _logger;
	private readonly IUnitOfWork _unitOfWork;

	public UserService(IUnitOfWork unitOfWork, ILogger<UserService> logger)
	{
		_unitOfWork = Guard.Against.Null(unitOfWork, nameof(unitOfWork));
		_logger = Guard.Against.Null(logger, nameof(logger));
	}

	public LoggedInUser? LoginUser(LoginModel model)
	{
		LoggedInUser? result = Guard.Against.Null(_unitOfWork.User.LoginUser(model), nameof(LoggedInUser));

		_logger.LogInformation("Returning loggedInUser");

		return result;
	}

	/// <summary>
	///   Gets the user by identifier asynchronously.
	/// </summary>
	/// <param name="id">The identifier.</param>
	/// <returns>The userDto if found; otherwise, null.</returns>
	public async Task<UserDto?> GetByIdAsync(ObjectId id)
	{
		Guard.Against.EmptyObjectId(id, nameof(id));

		try
		{
			User user = Guard.Against.Null(await _unitOfWork.User.GetByIdAsync(id));

			_logger.LogInformation("Returned user with id: {id}", id);

			UserDto result = user.MapToUserDto();

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogError("Something went wrong inside GetByIdAsync action: {ExceptionMessage}", ex.Message);
			return null;
		}
	}

	/// <summary>
	///   Gets all users asynchronously.
	/// </summary>
	/// <returns>A collection of userDto if found; otherwise, null.</returns>
	public async Task<IEnumerable<UserDto?>?> GetUsersAsync(int count, int page)
	{
		try
		{
			IQueryable<User> users = Guard.Against.Null(await _unitOfWork.User.GetAllAsync(count, page));

			_logger.LogInformation("Returned users");

			List<UserDto> result = [];

			foreach (User user in users)
			{
				result.Add(user.MapToUserDto());
			}

			return result;
		}
		catch (Exception ex)
		{
			_logger.LogError("Something went wrong inside GetUsersAsync action: {ExceptionMessage}", ex.Message);
			return null;
		}
	}

	/// <summary>
	///   Gets the queryable users asynchronously.
	/// </summary>
	/// <returns>A queryable collection of userDtos if found; otherwise, null.</returns>
	public async Task<IQueryable<UserDto?>?> GetQuerableUsersAsync(int count, int page)
	{
		try
		{
			IQueryable<User> users = Guard.Against.Null(await _unitOfWork.User.GetAllAsync(count, page));

			_logger.LogInformation("Returned IQueryable users");

			List<UserDto> results = [];

			foreach (User user in users)
			{
				results.Add(user.MapToUserDto());
			}

			return (IQueryable<UserDto?>?)results.AsQueryable();
		}
		catch (Exception ex)
		{
			_logger.LogError("Something went wrong inside QueryableUsersAsync action: {ExceptionMessage}", ex.Message);
			return null;
		}
	}

	/// <summary>
	///   Creates a new user asynchronously.
	/// </summary>
	/// <param name="model">The userDto.</param>
	/// <returns>The result of the method execution.</returns>
	public async Task<MethodResult> CreateUserAsync(UserDto model)
	{
		Guard.Against.Null(model, nameof(model));

		bool exists = await _unitOfWork.User.AnyAsync(c => c.Id == model.Id);

		if (exists)
		{
			_logger.LogError("This user already exists.");

			return MethodResult.Failure("This user already exists");
		}

		// Convert to user entity

		User entity = model.MapToUser();

		_unitOfWork.User.Create(entity);

		return await _unitOfWork.CompleteAsync() > 0
			? MethodResult.Success()
			: MethodResult.Failure("Unknown error occurred while saving the blog post");
	}

	/// <summary>
	///   Updates an existing user asynchronously.
	/// </summary>
	/// <param name="model">The userDto.</param>
	/// <returns>The result of the method execution.</returns>
	public async Task<MethodResult> UpdateUserAsync(UserDto model)
	{
		bool exists = await _unitOfWork.User.AnyAsync(c => c.Id == model.Id);

		if (!exists)
		{
			return MethodResult.Failure("This user does not exist");
		}

		User entity = model.MapToUser();

		_unitOfWork.User.Update(entity);

		return await _unitOfWork.CompleteAsync() > 0
			? MethodResult.Success()
			: MethodResult.Failure("Unknown error occurred while saving the blog post");
	}

	/// <summary>
	///   Deletes an existing user asynchronously.
	/// </summary>
	/// <param name="model">The userDto.</param>
	/// <returns>The result of the method execution.</returns>
	public async Task<MethodResult> DeleteUserAsync(UserDto model)
	{
		bool exists = await _unitOfWork.User.AnyAsync(c => c.Id == model.Id);

		if (!exists)
		{
			_logger.LogError("This user does not exist.");
			return MethodResult.Failure("This user does not exist");
		}

		User entity = model.MapToUser();

		_unitOfWork.User.Update(entity);

		return await _unitOfWork.CompleteAsync() > 0
			? MethodResult.Success()
			: MethodResult.Failure("Unknown error occurred while saving the blog post");
	}
}