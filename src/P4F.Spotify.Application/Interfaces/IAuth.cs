using P4F.Spotify.Application.Auth;
using Refit;

namespace P4F.Spotify.Application.Interfaces
{
    public interface IAuth
    {
        [Headers("Content-Type: application/x-www-form-urlencoded")]
        [Post("/token")]
        Task<ApiResponse<TokenResponse>> GetToken([Body(BodySerializationMethod.UrlEncoded)] TokenRequest request);

    }
}
