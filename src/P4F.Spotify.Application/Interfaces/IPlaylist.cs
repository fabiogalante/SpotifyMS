using P4F.Spotify.Application.Playlist;
using Refit;

namespace P4F.Spotify.Application.Interfaces
{
    public interface IPlaylist
    {
        [Get("/playlists/{playlist_id}")]
        Task<PlaylistResponse> GetPlaylist(string? playlist_id);
    }
}
