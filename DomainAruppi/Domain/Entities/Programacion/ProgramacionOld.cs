using DomainAruppi.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Domain.Entities
{
    public class Genre
    {
        public string name { get; set; }
       
    }

    public class Series
    {
        public string mal_id { get; set; }      
        public string title { get; set; }
        public string image_url { get; set; }
      
       
    }


    public class ProgramacionOld
    {

        public List<Series> monday { get; set; }

        public List<Series> tuesday { get; set; }

        public List<Series> wednesday { get; set; }

        public List<Series> thursday { get; set; }

        public List<Series> friday { get; set; }

        public List<Series> saturday { get; set; }

        public List<Series> sunday { get; set; }       
        
       
            
    }
    public class Day
    {
        public List<Series> day { get; set; }
    }

}
