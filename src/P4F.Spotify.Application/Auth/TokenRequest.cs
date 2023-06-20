namespace P4F.Spotify.Application.Auth
{
    public record TokenRequest
    {
        public TokenRequest(string grantType, string clientId, string clientSecret)
        {
            grant_type = grantType;
            client_id = clientId;
            client_secret = clientSecret;
        }

        public string grant_type { get; set; }
        public string client_id { get; set; }
        public string client_secret { get; set; }
    }
}
