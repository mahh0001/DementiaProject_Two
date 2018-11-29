using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DementiaProject_Two.Models;

namespace DementiaProject_Two.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {

            var user = new UserInfoViewModel() { FirstName = "Lars", LastName = "Larsen", Age = 72, Gender = "Mand", ZipCode = 0000 };
            return View(user);
        }
    }
}