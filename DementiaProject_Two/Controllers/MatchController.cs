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
                new UserInfoViewModel { Age = 1000, FirstName = "Pai", LastName = "Mai", Gender = "Male", ZipCode = 5000, Id = 1, PreferedActivities = new List<string>(){"Løb", "Karate"}},
                new UserInfoViewModel
                    {Age = 96, FirstName = "Betty", LastName = "White", Gender = "Female", ZipCode = 5000, Id = 2, PreferedActivities = new List<string>(){"Svømning", "Pølse"}},
                new UserInfoViewModel {Age = 70, FirstName = "Rimor", LastName = "Petersen", Gender = "Female", ZipCode = 5000, Id = 3, PreferedActivities = new List<string>(){"Springgymnastik", "Fodbold", "Badminton"}},
                new UserInfoViewModel {Age = 57, FirstName = "George", LastName = "Cloney", Gender = "Male", ZipCode = 5000, Id = 4, PreferedActivities = new List<string>(){"Fodbold", "Tennis"}},
                new UserInfoViewModel {Age = 62, FirstName = "Daniel", LastName = "Black", Gender = "Male", ZipCode = 5000, Id = 5, PreferedActivities = new List<string>(){"Løb", "Badminton"} }

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