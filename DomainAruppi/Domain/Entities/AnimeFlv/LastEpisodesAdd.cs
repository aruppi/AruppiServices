
public class LastEpisodesAdd
{
    public Episode[] episodes { get; set; }
}

public class Episode
{
    public string title { get; set; }
    public string poster { get; set; }
    public int episode { get; set; }
    public Server[] servers { get; set; }
}

public class Server
{
    public string server { get; set; }
    public string title { get; set; }
    public bool allow_mobile { get; set; }
    public string code { get; set; }
    public string url { get; set; }
}
