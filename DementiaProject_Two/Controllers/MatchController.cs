using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
                new UserInfoViewModel { Age = 25, FirstName = "Mathias", LastName = "Nielsen", Gender = "Male", ZipCode = 5000, Id = new Guid("68510210-1c74-4ae0-8109-f3da7f98e504"), PreferedActivities = new List<string>(){"Løb", "Karate"}},
                new UserInfoViewModel
                    {Age = 25, FirstName = "Hafsteinn", LastName = "Ragnarsson", Gender = "Male", ZipCode = 5000, Id = new Guid("60b13122-0bca-4377-bcea-0972c1a87c9f"), PreferedActivities = new List<string>(){"Svømning"}},
                new UserInfoViewModel {Age = 23, FirstName = "Rasmus", LastName = "Petersen", Gender = "Male", ZipCode = 5000, Id = new Guid("dae58f8a-14fd-4450-a337-dd42faeb88b5"), PreferedActivities = new List<string>(){"Springgymnastik", "Fodbold", "Badminton"}},
                new UserInfoViewModel {Age = 36, FirstName = "Jesper", LastName = "Johansen", Gender = "Male", ZipCode = 5000, Id = new Guid("761ffa35-0a7f-4e04-8c9f-48fe48b5cc1c"), PreferedActivities = new List<string>(){"Fodbold", "Tennis"}},
                new UserInfoViewModel {Age = 21, FirstName = "Daniel", LastName = "Stuhr", Gender = "Male", ZipCode = 5000, Id = new Guid("383f16d5-b7d7-4aef-b17f-44e6cd8e2bd8"), PreferedActivities = new List<string>(){"Løb", "Badminton"} }

            };
            return PartialView("_UserInfo", users.ElementAt(new Random().Next(0, users.Count)));
        }

    }
}