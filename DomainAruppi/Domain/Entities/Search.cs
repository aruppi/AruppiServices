using System;
using System.Collections.Generic;
using System.Text;

namespace DomainAruppi.Domain.Entities
{
    public class Result
    {
        public int mal_id { get; set; }
      
    }

    public class Search
    {       
        public List<Result> results { get; set; }
       
    }
}
