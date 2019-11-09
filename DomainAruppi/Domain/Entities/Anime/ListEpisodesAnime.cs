using System;
using System.Collections.Generic;
using System.Text;

namespace DomainAruppi.Domain.Entities
{
    public class Episode
    {
        public int episode_id { get; set; }
        public string title { get; set; }
        public object title_japanese { get; set; }
        public object title_romanji { get; set; }
        public object aired { get; set; }
        public bool filler { get; set; }
        public bool recap { get; set; }
        public string video_url { get; set; }
        public string forum_url { get; set; }
    }

    public class ListEpisodesAnime
    {
        public int episodes_last_page { get; set; }
        public List<Episode> episodes { get; set; }
    }
}
