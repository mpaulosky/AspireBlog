namespace AspireBlog.Common.Interfaces;

public interface IUserService
{
	LoggedInUser? LoginUser(LoginModel model);
	Task<UserDto?> GetByIdAsync(ObjectId id);
	Task<IEnumerable<UserDto?>?> GetUsersAsync(int count, int page);
	Task<IQueryable<UserDto?>?> GetQuerableUsersAsync(int count, int page);
	Task<MethodResult> CreateUserAsync(UserDto model);
	Task<MethodResult> UpdateUserAsync(UserDto model);
	Task<MethodResult> DeleteUserAsync(UserDto model);
}