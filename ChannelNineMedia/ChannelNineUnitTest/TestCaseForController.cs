using System;
using ChannelNineMedia.Controllers;
using ChannelNineMedia.Models;
using ChannelNineMedia.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace ChannelNineUnitTest
{
    [TestClass]
    public class TestCaseForController
    {
        //Arrange
       private readonly PersonService _service = new PersonService();
       private readonly PersonController controller = new PersonController();

        [TestMethod]
        public void TestMethodForGet()
        {
            //SetValues
           var result =  controller.Index() as ViewResult;
            //Result
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestMethodForPost()
        {
            //SetValues
            PersonViewModel model = new PersonViewModel()
            {
               Races = "Angles"
            };
            var result = controller.Index(model) as ViewResult;
            //Result
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void TestMethodForPostMethodPassingNullModel()
        {
            //SetValues
            PersonViewModel model = new PersonViewModel();
            var result = controller.Index(model) as ViewResult;
            //Result
           Assert.IsNotNull(result);
        }
    }
}
