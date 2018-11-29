using System.Collections.Generic;
using DementiaProject_Two.Models;
using Microsoft.AspNetCore.Mvc;


namespace DementiaProject_Two.Controllers
{
    [Route("[controller]")]
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            var user = new UserInfoViewModel() { FirstName = "Lars", LastName = "Larsen", Age = 72, Gender = "Mand", ZipCode = 0000 };

            return View(user);   
        }

        [HttpPost]
        public ActionResult EditProfil([Bind(include:"ID, FirstName, LastName, Gender, Id, ZipCode")] UserInfoViewModel userModel)
        {
            if (userModel == null)
            {
                return NotFound("Could not find the user");
            }
            if (ModelState.IsValid)
            {
                return View(userModel);
            }

            return View();
            }

    }
}