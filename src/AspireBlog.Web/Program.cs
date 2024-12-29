// set

#region

using AspireBlog.Web;
using AspireBlog.Web.Components;
using AspireBlog.Web.Extensions;

using Auth0.AspNetCore.Authentication;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;

#endregion

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();
builder.AddRedisOutputCache("cache");

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.AddDbContextFactory();

builder.Services.AddCascadingAuthenticationState();

builder.Services
	.AddAuth0WebAppAuthentication(options =>
	{
		options.Domain = builder.Configuration["Auth0:Authority"] ?? "";
		options.ClientId = builder.Configuration["Auth0:ClientId"] ?? "";
	});

builder.Services.AddScoped<AuthenticationStateProvider, PersistingServerAuthenticationStateProvider>();

WebApplication? app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.UseOutputCache();

app.MapStaticAssets();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.MapDefaultEndpoints();

app.MapGet("Account/Login", async (string returnUrl, HttpContext context) =>
{
	AuthenticationProperties? authenticationProperties = new LoginAuthenticationPropertiesBuilder()
		.WithRedirectUri(returnUrl)
		.Build();
	await context.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
});

app.MapGet("authentication/logout", async context =>
{
	AuthenticationProperties? authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
		.WithRedirectUri("/")
		.Build();
	await context.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
	await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
});

app.Run();