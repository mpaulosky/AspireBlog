using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AspireBlog.Web.Pages;

public class LogoutModel : PageModel
{
	public async Task OnGet()
	{
		var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
			.WithRedirectUri("/")
			.Build();

		await HttpContext.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
		await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
	}
}