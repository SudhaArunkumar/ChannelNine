using System;
using ChannelNineMedia.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ChannelNineMedia.Services
{
    public class PersonService
    {
        /// <summary>
        /// This method is used to Load the Dropdown Race List first Time Load
        /// </summary>
        /// <returns></returns>
        public PersonViewModel DefaultDropDoown(bool IsDefault,PersonViewModel model)
        {
            if (IsDefault)
            {
                model = new PersonViewModel();
                model.RacesList = RacesDropDownList();
            }
            else
                model.RacesList = RacesDropDownList();
            return model;
        }
        /// <summary>
        /// This private method load the Races drop down list
        /// </summary>
        /// <returns></returns>
        private IEnumerable<SelectListItem> RacesDropDownList()
        {
            List<SelectListItem> raceList = new List<SelectListItem>();
            raceList.Add(new SelectListItem() { Text = "Select Races", Value = "" });
            raceList.Add(new SelectListItem() { Text = Races.Angles, Value = Races.Angles });
            raceList.Add(new SelectListItem() { Text = Races.Saxons, Value = Races.Saxons });
            raceList.Add(new SelectListItem() { Text = Races.Jutes, Value = Races.Jutes });
            raceList.Add(new SelectListItem() { Text = Races.Hawaiian, Value = Races.Hawaiian });

            return raceList;
        }
        /// <summary>
        /// This method is used to populate the list 
        /// </summary>
        /// <param name="races"></param>
        /// <returns></returns>
        public List<SearchPerson> GetSearchPersonList(string races)
        {
            List<SearchPerson> personList = new List<SearchPerson>();
            if (!string.IsNullOrEmpty(races))
            {
                using (PersonContext context = new PersonContext())
                {
                    var person = context.person.Where(p => p.Races == races && p.Age / 2 == 0).ToList();
                    foreach (var item in person)
                    {
                        SearchPerson searchPerson = new SearchPerson();
                        searchPerson.PersonName = item.PersonName;
                        searchPerson.Races = item.Races;
                        searchPerson.Age = item.Age;
                        searchPerson.Height = item.Height;
                        personList.Add(searchPerson);
                    }
                    context.Database.Connection.Close();
                }
            } 
            return personList;
        }
    }
}