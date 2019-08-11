using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ChunckAPI.Models;
using ChannelNineMedia.Models;
using System.Web.Http;
using System.IO;

namespace ChunckAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values/
        /// <summary>
        /// This Method getting the number of people in PersonTable
        /// </summary>
        public void GetNumberofPeople()
        {
            using (PersonContext context = new PersonContext())
            {
                var result = context.person.Select(p => p).ToList();
                if (result != null)
                {
                    NumberPeopleCount count = new NumberPeopleCount();
                    count.PeopleCount = result.Count();
                    string jsonCount = JsonConvert.SerializeObject(count);
                    File.WriteAllText(@"NumberPeopleCount.json", jsonCount);
                }
            }
        }
        /// <summary>
        /// This method is used to get the average people age 
        /// </summary>
        public void GetAverageMaxandMinAge()
        {
            using (PersonContext context = new PersonContext())
            {
                var result = context.person.Select(p => p).ToList();
                if (result != null)
                {
                    var max = result.Max(p => p.Age);
                    var min = result.Min(p => p.Age);
                    var avg = (max + min) / 2;
                    AveragePeopleAge average = new AveragePeopleAge();
                    average.MaxAge = max;
                    average.MinAge = min;
                    average.AverageAge = avg;
                    string jsonCount = JsonConvert.SerializeObject(average);
                    File.WriteAllText(@"AveragePeopleAge.json", jsonCount);
                }
            }
        }
        /// <summary>
        /// This method is used to get the RacesList and Count
        /// </summary>
        public void GetRacesPeopleCount()
        {
            List<RaceswithCount> raceList = new List<RaceswithCount>();
            using (PersonContext context = new PersonContext())
            {
                var result = context.person.Select(p => p).ToList();
                if (result != null)
                {
                    var racesList = result.GroupBy(p => p.Races).Select(p => new {
                        Races = p.Key,
                        count = p.Count()
                    }).OrderBy(p => p.Races).ToList();
                    if (racesList != null)
                    {
                        foreach (var item in racesList)
                        {
                            RaceswithCount racewithCount = new RaceswithCount();
                            racewithCount.Races = item.Races;
                            racewithCount.Count = item.count;
                            raceList.Add(racewithCount);
                        }
                    }
                    string jsonRacewithCount = JsonConvert.SerializeObject(raceList);
                    File.WriteAllText(@"RacewithCount.json", jsonRacewithCount);
                }
            }
        }
    }
}