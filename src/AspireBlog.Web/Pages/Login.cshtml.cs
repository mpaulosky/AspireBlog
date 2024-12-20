using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspireBlog.Web.Pages;

public class LoginModel : PageModel
{
	public async Task OnGet(string redirectUri)
	{
		var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
			.WithRedirectUri(redirectUri)
			.Build();

		await HttpContext.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
	}
}