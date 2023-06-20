namespace P4F.Spotify.Application.Settings;

public sealed record SpotifySettings
{
    public static string Key = "SpotifySettings";
    public string Uri { get; set; } = string.Empty;
    public string UriToken { get; set; } = string.Empty;
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
    public string GrantType { get; set; } = string.Empty;
    
}