using Microsoft.AspNetCore.Mvc;
using P4F.Spotify.Application.Interfaces;
using P4F.Spotify.Application.Playlist;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlaylistController : BaseApiController
{


    private readonly IPlaylist _playlist;

    public PlaylistController(IPlaylist playlist)
    {
        _playlist = playlist;
    }

    [HttpGet("GetPlaylist/{playListId}")]
    public async Task<IActionResult> GetPlaylist(string playListId)
    {
        return HandleResult(await Mediator.Send(new List.Query { PlayListId = playListId}));

        var playlist =  await _playlist.GetPlaylist(playListId);

        return Ok();
    }
}