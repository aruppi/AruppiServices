using Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainAruppi.Domain.Entities
{  

    public class Anime
    {
        public int mal_id { get; set; }
        public string url { get; set; }
        public string title { get; set; }
        public string image_url { get; set; }
        public string synopsis { get; set; }
        public string type { get; set; }
        public DateTime? airing_start { get; set; }
        public int? episodes { get; set; }
        public List<Genre> genres { get; set; }
    }

    public class Seasons
    {       
        public string season_name { get; set; }
        public int season_year { get; set; }
        public List<Anime> anime { get; set; }
       
    }
}
