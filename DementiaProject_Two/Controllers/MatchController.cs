using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DementiaProject_Two.Controllers
{
    [Route("match")]
    public class MatchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // This implementation is for testing the view only!!
        [HttpGet("next")]
        public IActionResult GetNextUserPartialView()
        {
            var users = new List<UserInfoViewModel>()
            {
                new UserInfoViewModel { Age = 25, FirstName = "Mathias", LastName = "Nielsen", Gender = "Male", ZipCode = 5000, Id = 1, PreferedActivities = new List<string>(){"Løb", "Karate"}},
                new UserInfoViewModel
                    {Age = 25, FirstName = "Hafsteinn", LastName = "Ragnarsson", Gender = "Male", ZipCode = 5000, Id = 2, PreferedActivities = new List<string>(){"Svømning"}},
                new UserInfoViewModel {Age = 23, FirstName = "Rasmus", LastName = "Petersen", Gender = "Male", ZipCode = 5000, Id = 3, PreferedActivities = new List<string>(){"Springgymnastik", "Fodbold", "Badminton"}},
                new UserInfoViewModel {Age = 36, FirstName = "Jesper", LastName = "Johansen", Gender = "Male", ZipCode = 5000, Id = 4, PreferedActivities = new List<string>(){"Fodbold", "Tennis"}},
                new UserInfoViewModel {Age = 21, FirstName = "Daniel", LastName = "Stuhr", Gender = "Male", ZipCode = 5000, Id = 5, PreferedActivities = new List<string>(){"Løb", "Badminton"} }

            };
            return PartialView("_UserInfo", users.ElementAt(new Random().Next(0, users.Count)));
         
        }

    }

    public class UserInfoViewModel
    {
        public int Age { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int ZipCode { get; set; }
        public long Id { get; set; }
        public List<string> PreferedActivities { get; set; }
    }
}