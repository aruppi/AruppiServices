
public class LastAnimes
{
    public Anime[] animes { get; set; }
}

public class Anime
{
    public string title { get; set; }
    public string poster { get; set; }
    public string synopsis { get; set; }
    public string debut { get; set; }
    public string type { get; set; }
    public string rating { get; set; }
    public EpisodeAnime[] episodes { get; set; }
}

public class EpisodeAnime
{
    public string nextEpisodeDate { get; set; }
    public int episode { get; set; }
    public string id { get; set; }
}
