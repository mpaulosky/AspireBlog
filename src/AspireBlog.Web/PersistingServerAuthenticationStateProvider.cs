// set

#region

using System.Diagnostics;
using System.Security.Claims;

using AspireBlog.Abstractions.Models;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

#endregion

namespace AspireBlog.Web;

// This is a server-side AuthenticationStateProvider that uses PersistentComponentState to flow the
// authentication state to the client which is then fixed for the lifetime of the WebAssembly application.
internal sealed class PersistingServerAuthenticationStateProvider : ServerAuthenticationStateProvider, IDisposable
{
	private readonly IdentityOptions _options;
	private readonly PersistentComponentState _state;

	private readonly PersistingComponentStateSubscription _subscription;

	private Task<AuthenticationState>? _authenticationStateTask;

	public PersistingServerAuthenticationStateProvider(
		PersistentComponentState persistentComponentState,
		IOptions<IdentityOptions> optionsAccessor)
	{
		_state = persistentComponentState;
		_options = optionsAccessor.Value;

		AuthenticationStateChanged += OnAuthenticationStateChanged;
		_subscription = _state.RegisterOnPersisting(OnPersistingAsync, RenderMode.InteractiveAuto);
	}

	public void Dispose()
	{
		_subscription.Dispose();
		AuthenticationStateChanged -= OnAuthenticationStateChanged;
	}

	private void OnAuthenticationStateChanged(Task<AuthenticationState> task)
	{
		_authenticationStateTask = task;
	}

	private async Task OnPersistingAsync()
	{
		if (_authenticationStateTask is null)
		{
			throw new UnreachableException($"Authentication state not set in {nameof(OnPersistingAsync)}().");
		}

		AuthenticationState? authenticationState = await _authenticationStateTask;
		ClaimsPrincipal? principal = authenticationState.User;

		if (principal.Identity?.IsAuthenticated == true)
		{
			string? userId = principal.FindFirst(_options.ClaimsIdentity.UserIdClaimType)?.Value;
			string? name = principal.FindFirst(_options.ClaimsIdentity.UserNameClaimType)?.Value;
			string? email = principal.FindFirst(_options.ClaimsIdentity.EmailClaimType)?.Value;
			string[]? roles = principal.Claims.Where(c => c.Type == _options.ClaimsIdentity.RoleClaimType)
				.Select(c => c.Value).ToArray();

			if (userId != null)
			{
				_state.PersistAsJson(nameof(UserInfo),
					new UserInfo { UserId = userId, Name = name!, Email = email, Roles = roles });
			}
		}
	}
}