// set

namespace AspireBlog.Data.Mongo.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
	LoggedInUser? LoginUser(LoginModel model);
}