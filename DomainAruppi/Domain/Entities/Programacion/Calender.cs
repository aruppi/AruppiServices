using System;
using System.Collections.Generic;
using System.Text;

namespace DomainAruppi.Domain.Entities
{
    public class Monday
    {
        public List<string> title { get; set; }
        public List<string> id { get; set; }
        public List<string> poster { get; set; }
    }

    public class Tuesday
    {
        public List<string> title { get; set; }
        public List<string> id { get; set; }
        public List<string> poster { get; set; }
    }

    public class Wednesday
    {
        public List<string> title { get; set; }
        public List<string> id { get; set; }
        public List<string> poster { get; set; }
    }

    public class Thursday
    {
        public List<string> title { get; set; }
        public List<string> id { get; set; }
        public List<string> poster { get; set; }
    }

    public class Friday
    {
        public List<string> title { get; set; }
        public List<string> id { get; set; }
        public List<string> poster { get; set; }
    }

    public class Saturday
    {
        public List<string> title { get; set; }
        public List<string> id { get; set; }
        public List<string> poster { get; set; }
    }

    public class Sunday
    {
        public List<string> title { get; set; }
        public List<string> id { get; set; }
        public List<string> poster { get; set; }
    }

    public class Calender
    {
        public List<Monday> monday { get; set; }
        public List<Tuesday> tuesday { get; set; }
        public List<Wednesday> wednesday { get; set; }
        public List<Thursday> thursday { get; set; }
        public List<Friday> friday { get; set; }
        public List<Saturday> saturday { get; set; }
        public List<Sunday> sunday { get; set; }
    }

    public class Schedule
    {
        public List<Calender> calender { get; set; }
    }
}
