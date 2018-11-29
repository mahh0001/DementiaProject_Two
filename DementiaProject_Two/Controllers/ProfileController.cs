using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DementiaProject_Two.Models;
using Microsoft.AspNetCore.Mvc;


namespace DementiaProject_Two.Controllers
{
    [Route("[controller]/[action]")]
    public class ProfileController : Controller
    {
        [Route("{id}")]
        public IActionResult Index(int? id)
        { 
            if (id == null)
            {
                return BadRequest("Could not find user");
            }
            List<UserInfoViewModel> user = new List<UserInfoViewModel>
            {
                new UserInfoViewModel()
                {
                    Age = 20,
                    FirstName = "Razz",
                    LastName = "Pazzaz",
                    Gender = "Dont care dont know",
                    Id = 1234,
                    ZipCode = 5000,
                }
            };

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