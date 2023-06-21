using Microsoft.AspNetCore.Mvc;
using P4F.Spotify.Application.Playlist;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlaylistController : BaseApiController
{

    [HttpGet("GetPlaylist/{playListId}")]
    public async Task<IActionResult> GetPlaylist(string playListId)
    {
        return HandleResult(await Mediator.Send(new List.Query { PlayListId = playListId}));
    }
}