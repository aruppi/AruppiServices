using System;
using System.Collections.Generic;
using System.Text;

namespace DomainAruppi.Domain.Entities
{
    public class Post
    {
        public int id { get; set; }      
        public string small_preview { get; set; }
        public string medium_preview { get; set; }
        public string big_preview { get; set; }       
    }

    public class Wallpapers
    {
        public int max_pages { get; set; }
        public List<Post> posts { get; set; }        
    }
}
