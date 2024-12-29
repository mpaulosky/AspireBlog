// set

namespace AspireBlog.Abstractions.Interfaces;

public interface ILoginProvider
{
	Task LoginAsync();
	Task LogoutAsync();
}