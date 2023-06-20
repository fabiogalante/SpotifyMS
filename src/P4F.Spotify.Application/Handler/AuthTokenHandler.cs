using P4F.Spotify.Application.Settings;
using Microsoft.Extensions.Options;
using P4F.Spotify.Application.Interfaces;
using System.Net.Http.Headers;
using P4F.Spotify.Application.Auth;

namespace P4F.Spotify.Application.Handler;

public class AuthTokenHandler : DelegatingHandler
{
    private readonly SpotifySettings _settings;
    private readonly IAuth _auth;

    public AuthTokenHandler(IOptions<SpotifySettings> settings, IAuth auth)
    {
        _auth = auth;
        _settings = settings.Value;
    }

    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        var tokenRequest = new TokenRequest(_settings.GrantType,  _settings.ClientId, _settings.ClientSecret);
        var token = await _auth.GetToken(tokenRequest);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Content?.access_token);
        return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
    }
}

