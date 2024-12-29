using System.Diagnostics;

using AspireBlog.Web.Models;

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace AspireBlog.Web;

// This is a server-side AuthenticationStateProvider that uses PersistentComponentState to flow the
// authentication state to the client which is then fixed for the lifetime of the WebAssembly application.
internal sealed class PersistingServerAuthenticationStateProvider : ServerAuthenticationStateProvider, IDisposable
{
	private readonly PersistentComponentState _state;
	private readonly IdentityOptions options;

	private readonly PersistingComponentStateSubscription _subscription;

	private Task<AuthenticationState>? _authenticationStateTask;

	public PersistingServerAuthenticationStateProvider(
			PersistentComponentState persistentComponentState,
			IOptions<IdentityOptions> optionsAccessor)
	{
		_state = persistentComponentState;
		options = optionsAccessor.Value;

		AuthenticationStateChanged += OnAuthenticationStateChanged;
		_subscription = _state.RegisterOnPersisting(OnPersistingAsync, RenderMode.InteractiveAuto);
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

		var authenticationState = await _authenticationStateTask;
		var principal = authenticationState.User;

		if (principal.Identity?.IsAuthenticated == true)
		{
			var userId = principal.FindFirst(options.ClaimsIdentity.UserIdClaimType)?.Value;
			var email = principal.FindFirst("Name")?.Value;
			var roles = principal.Claims.Where(c => c.Type == options.ClaimsIdentity.RoleClaimType).Select(c => c.Value).ToArray();
			if (userId != null)
			{
				_state.PersistAsJson(nameof(UserInfo), new UserInfo
				{
					UserId = userId,
					Email = email,
					Roles = roles
				});
			}
		}
	}

	public void Dispose()
	{
		_subscription.Dispose();
		AuthenticationStateChanged -= OnAuthenticationStateChanged;
	}
}
