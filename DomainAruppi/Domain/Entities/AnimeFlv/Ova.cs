
public class Ovas
{
    public Ovum[] ova { get; set; }
}

public class Ovum
{
    public string title { get; set; }
    public string poster { get; set; }
    public string synopsis { get; set; }
    public object debut { get; set; }
    public string type { get; set; }
    public string rating { get; set; }
    public string[] genres { get; set; }
    public EpisodeOvas[] episodes { get; set; }
}

public class EpisodeOvas
{
    public object nextEpisodeDate { get; set; }
    public int episode { get; set; }
    public string id { get; set; }
    public string imagePreview { get; set; }
}
