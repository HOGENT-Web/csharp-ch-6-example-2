using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Components;

namespace Project.Client.Shared;

public class FakeAuthorizationMessageHandler : DelegatingHandler
{
    private readonly FakeAuthenticationProvider fakeAuthenticationProvider;

    public FakeAuthorizationMessageHandler(FakeAuthenticationProvider fakeAuthenticationProvider)
    {
        this.fakeAuthenticationProvider = fakeAuthenticationProvider;
    }
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
    {
        request.Headers.Add("UserId", fakeAuthenticationProvider.Current.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        request.Headers.Add("Role", fakeAuthenticationProvider.Current.FindFirst(ClaimTypes.Role)?.Value);
        request.Headers.Add("Email", fakeAuthenticationProvider.Current.FindFirst(ClaimTypes.Email)?.Value);
        return base.SendAsync(request, cancellationToken);
    }
}

