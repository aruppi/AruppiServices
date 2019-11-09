using System;
using System.Collections.Generic;
using System.Text;

namespace DomainAruppi.Domain.Entities.episodes
{
    public class Anime
    {
        public string title { get; set; }
        public string id { get; set; }
        public string poster { get; set; }
        public string type { get; set; }
        public string synopsis { get; set; }
        public string state { get; set; }
    }

    public class IdAnime
    {
        public List<Anime> animes { get; set; }
    }
}
