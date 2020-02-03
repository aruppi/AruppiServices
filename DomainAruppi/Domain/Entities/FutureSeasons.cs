
using Domain.Domain.Entities;
using System.Collections.Generic;

public class FutureSeasons
{
    public string season_name { get; set; }
    public object season_year { get; set; }
    public JinkanAnime[] anime { get; set; }
}

public class JinkanAnime
{
    public int mal_id { get; set; }
    public string url { get; set; }
    public string title { get; set; }
    public string image_url { get; set; }
    public string synopsis { get; set; }
    public string type { get; set; }
    public object airing_start { get; set; }
    public int? episodes { get; set; }
    public int members { get; set; }
   // public List<Genre> genres { get; set; }
    public string source { get; set; }
    public Producer[] producers { get; set; }
    public object score { get; set; }
    public string[] licensors { get; set; }
    public bool r18 { get; set; }
    public bool kids { get; set; }
    public bool continuing { get; set; }
}

public class Producer
{
    public int mal_id { get; set; }
    public string type { get; set; }
    public string name { get; set; }
    public string url { get; set; }
}
