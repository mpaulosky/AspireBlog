using AspireBlog.Web;
using AspireBlog.Web.Components;

using Auth0.AspNetCore.Authentication;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();
builder.AddRedisOutputCache("cache");

// Add services to the container.
builder.Services.AddRazorComponents()
		.AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
builder.Services
		.AddAuth0WebAppAuthentication(options =>
		{
			options.Domain = builder.Configuration["Auth0:Authority"] ?? ""; ;
			options.ClientId = builder.Configuration["Auth0:ClientId"] ?? ""; ;
		});
builder.Services.AddScoped<AuthenticationStateProvider, PersistingServerAuthenticationStateProvider>();

builder.Services.AddHttpClient<WeatherApiClient>(client =>
		{
			// This URL uses "https+http://" to indicate HTTPS is preferred over HTTP.
			// Learn more about service discovery scheme resolution at https://aka.ms/dotnet/sdschemes.
			client.BaseAddress = new("https+http://apiservice");
		});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
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
	var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
			 .WithRedirectUri(returnUrl)
			 .Build();
	await context.ChallengeAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
});

app.MapGet("authentication/logout", async (HttpContext context) =>
{
	var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
			 .WithRedirectUri("/")
			 .Build();
	await context.SignOutAsync(Auth0Constants.AuthenticationScheme, authenticationProperties);
	await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
});

app.Run();