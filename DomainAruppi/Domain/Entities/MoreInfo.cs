using Domain.Domain.Entities;
using DomainAruppi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainAruppi.Domain.Entities
{    
    public class Aired
    {
        public DateTime from { get; set; }
        public object to { get; set; }       
        public string @string { get; set; }
    }

    public class Adaptation
    {
        public int? mal_id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class SideStory
    {
        public int? mal_id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }    

    public class Summary
    {
        public int? mal_id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class AlternativeVersion
    {
        public int? mal_id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Other
    {
        public int? mal_id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string url { get; set; }
    }
    public class Character
    {       
        public string image_url { get; set; }
        public string name { get; set; }        
    }
    public class Picture
    {
        public string large { get; set; }
        public string small { get; set; }
    }

    public class MoreInfo
{
    public int? mal_id { get; set; }   
    public string image_url { get; set; }
    public string trailer_url { get; set; }
    public string title { get; set; }   
    public string title_japanese { get; set; } 
    public bool airing { get; set; }
    public Aired aired { get; set; }
    public string duration { get; set; }
    public string rating { get; set; }
    public double? score { get; set; }    
    public int? rank { get; set; }      
    public string synopsis { get; set; }
    public string background { get; set; }    
    public string broadcast { get; set; }    
    public List<Genre> genres { get; set; }
    public List<string> opening_themes { get; set; }
    public List<string> ending_themes { get; set; }

        //Other services
     public List<Character> characters { get; set; }
     public List<Picture> pictures { get; set; }



        // imagenes

        //Traducción -------
        //background, synopsis ,  broadcast


        // personajes

    }
}
