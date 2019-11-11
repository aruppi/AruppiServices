
public class SearchAnimeFlv
{
    public SearchFlv[] search { get; set; }
}

public class SearchFlv
{
    public string title { get; set; }
    public string poster { get; set; }
    public string synopsis { get; set; }
    public object debut { get; set; }
    public string type { get; set; }
    public string rating { get; set; }
    public EpisodeSearch[] episodes { get; set; }
}

public class EpisodeSearch
{
    public string nextEpisodeDate { get; set; }
    public int episode { get; set; }
    public string id { get; set; }
}
