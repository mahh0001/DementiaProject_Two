using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DementiaProject_Two.Models;
using Microsoft.AspNetCore.Mvc;

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
                new UserInfoViewModel { Age = 25, FirstName = "Mathias", LastName = "Nielsen", Gender = "Male", ZipCode = 5000, Id = 01, PreferedActivities = new List<string>(){"Løb", "Karate"}},
                new UserInfoViewModel
                    {Age = 25, FirstName = "Hafsteinn", LastName = "Ragnarsson", Gender = "Male", ZipCode = 5000, Id = 02, PreferedActivities = new List<string>(){"Svømning"}},
                new UserInfoViewModel {Age = 23, FirstName = "Rasmus", LastName = "Petersen", Gender = "Male", ZipCode = 5000, Id = 03, PreferedActivities = new List<string>(){"Springgymnastik", "Fodbold", "Badminton"}},
                new UserInfoViewModel {Age = 36, FirstName = "Jesper", LastName = "Johansen", Gender = "Male", ZipCode = 5000, Id = 04, PreferedActivities = new List<string>(){"Fodbold", "Tennis"}},
                new UserInfoViewModel {Age = 21, FirstName = "Daniel", LastName = "Stuhr", Gender = "Male", ZipCode = 5000, Id = 05, PreferedActivities = new List<string>(){"Løb", "Badminton"} }

            };
            return PartialView("_UserInfo", users.ElementAt(new Random().Next(0, users.Count)));
        }

    }
}