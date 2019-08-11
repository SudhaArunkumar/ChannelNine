using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChannelNineMedia.Models
{
    //Database Context class
    public class Person
    {
        public int id { get; set; }
        public string PersonName { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public string Races { get; set; }
    }
}