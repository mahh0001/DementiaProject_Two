using System.Collections.Generic;
using DementiaProject_Two.Models;
using Microsoft.AspNetCore.Mvc;

namespace DementiaProject_Two.Controllers
{
    [Route("[controller]")]
    public class ProfileController : Controller
    {
        public IActionResult Index([Bind(include:"FirstName, LastName, Gender, Id, ZipCode")] UserInfoViewModel userModel)
        {
            var user = new UserInfoViewModel() { FirstName = "Lars", LastName = "Larsen", Age = 72, Gender = "Mand", ZipCode = 0000 };

            return View(user);   
        }
    }
}