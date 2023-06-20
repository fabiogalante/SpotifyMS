namespace P4F.Spotify.Application.Playlist;




public class ExternalUrls
{
    public string spotify { get; set; }
}

public class Followers
{
    public object href { get; set; }
    public int total { get; set; }
}

public class Image
{
    public object height { get; set; }
    public string url { get; set; }
    public object width { get; set; }
}

public class Owner
{
    public string display_name { get; set; }
    public ExternalUrls external_urls { get; set; }
    public string href { get; set; }
    public string id { get; set; }
    public string type { get; set; }
    public string uri { get; set; }
}

public class PlaylistResponse

{
    public bool collaborative { get; set; }
    public string description { get; set; }
    public ExternalUrls external_urls { get; set; }
    public Followers followers { get; set; }
    public string href { get; set; }
    public string id { get; set; }
    public List<Image> images { get; set; }
    public string name { get; set; }
    public Owner owner { get; set; }
    public object primary_color { get; set; }
    public bool @public { get; set; }
    public string snapshot_id { get; set; }
    public string type { get; set; }
    public string uri { get; set; }
}