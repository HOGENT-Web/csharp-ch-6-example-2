using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Project.Client.Shared;

public class FakeAuthenticationProvider : AuthenticationStateProvider
{
    public static ClaimsPrincipal Anonymous => new(new ClaimsIdentity(new[]
    {
            new Claim(ClaimTypes.Name, "Anonymous"),
    }));

    public static ClaimsPrincipal Administrator => new(new ClaimsIdentity(new[]
    {
        new Claim(ClaimTypes.NameIdentifier, "1"),
        new Claim(ClaimTypes.Name, "Fake Administrator"),
        new Claim(ClaimTypes.Email, "fake-administrator@gmail.com"),
        new Claim(ClaimTypes.Role, "Administrator"),
    }, "Fake Authentication"));

    public static ClaimsPrincipal Customer => new(new ClaimsIdentity(new[]
    {
        new Claim(ClaimTypes.NameIdentifier, "2"),
        new Claim(ClaimTypes.Name, "Fake Customer"),
        new Claim(ClaimTypes.Email, "fake-customer@gmail.com"),
        new Claim(ClaimTypes.Role, "Customer"),
    }, "Fake Authentication"));

    public ClaimsPrincipal Current { get; private set; } = Anonymous;

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return Task.FromResult(new AuthenticationState(Current));
    }

    public void ChangeAuthenticationState(ClaimsPrincipal claimsPrincipal)
    {
        Current = claimsPrincipal;
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}
