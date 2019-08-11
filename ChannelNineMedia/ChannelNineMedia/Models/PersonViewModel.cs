using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChannelNineMedia.Models
{
    public class PersonViewModel
    {
        public string Races { get; set; }
        public int Height { get; set; }
        public IEnumerable<SelectListItem> RacesList { get; set; }
        public List<SearchPerson> SearchPersonList { get; set; }
    }
    public class SearchPerson
    {
        public string PersonName { get; set; }
        public int Age { get; set; }
        public string Races { get; set; }
        public int Height { get; set; }
    }
}
public static class Races 
{
    public const string Angles = "Angles";
    public const string Saxons = "Saxons";
    public const string Jutes = "Jutes";
    public const string Hawaiian = "Hawaiian";



}