using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P4F.Spotify.Application.Auth
{
   

    public record TokenResponse(
        string access_token,
        string token_type,
        int expires_in
    );
}
