using System.Collections.Generic;

public class SerachServer
{
    public List<ServerFlv> servers { get; set; }
}

public class ServerFlv
{
    public string server { get; set; }
    public string title { get; set; }
    public bool allow_mobile { get; set; }
    public string code { get; set; }
    public string url { get; set; }
}
