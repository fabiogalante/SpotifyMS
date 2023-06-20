using MediatR;
using P4F.Spotify.Application.Core;
using P4F.Spotify.Application.Interfaces;

namespace P4F.Spotify.Application.Playlist
{
    public class List
    {
        public class Query : IRequest<Result<PlaylistResponse>>
        {
            public string? PlayListId { get; set; }
        }

        public class Handler : IRequestHandler<Query, Result<PlaylistResponse>>
        {

            private readonly IPlaylist _playlist;

            public Handler(IPlaylist playlist)
            {
                _playlist = playlist;
            }


            public async  Task<Result<PlaylistResponse>> Handle(Query request, CancellationToken cancellationToken)
            {
               var playlist =  await _playlist.GetPlaylist(request.PlayListId);

                return Result<PlaylistResponse>
                    .Success(playlist);
            }
        }
    }
}
