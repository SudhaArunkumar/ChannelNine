using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ChannelNineMedia.Services;
using ChannelNineMedia.Models;
using System.Web.Mvc;

namespace ChannelNineMedia.Controllers
{
    public class PersonController : Controller
    {
        // GET: Person
        /// <summary>
        /// This Method is used to Load the person view page 
        /// Its Load first time only.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            PersonService service = new PersonService();
            PersonViewModel person = new PersonViewModel();
            person = service.DefaultDropDoown(true, person);
            return View(person);
        }
        /// <summary>
        /// This method is used to Populate the races list based on the 
        /// dropdown selection
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Index (PersonViewModel model)
        {
            if(model != null)
            {
                PersonService service = new PersonService();
                model.SearchPersonList = service.GetSearchPersonList(model.Races);
            }
            return View(model);
        }
    }
}