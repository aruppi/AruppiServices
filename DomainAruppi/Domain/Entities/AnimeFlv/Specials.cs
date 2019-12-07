
public class Specials
{
    public Special[] special { get; set; }
}

public class Special
{
    public string title { get; set; }
    public string poster { get; set; }
    public string synopsis { get; set; }
    public object debut { get; set; }
    public string type { get; set; }
    public string rating { get; set; }
    public string[] genres { get; set; }
    public EpisodeSpecials[] episodes { get; set; }
}

public class EpisodeSpecials
{
    public object nextEpisodeDate { get; set; }
    public int episode { get; set; }
    public string id { get; set; }
    public string imagePreview { get; set; }
}
