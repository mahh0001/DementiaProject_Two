using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DementiaProject_Two.Models;
using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD

=======
>>>>>>> d5ff2831f927c2a67a0908f5638a89c91e48a35b

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
<<<<<<< HEAD


            var user = new UserInfoViewModel() { FirstName = "Lars", LastName = "Larsen", Age = 72, Gender = "Mand", ZipCode = 0000 };
            return View(user);

=======
>>>>>>> d5ff2831f927c2a67a0908f5638a89c91e48a35b
            if (userModel == null)
            {
                return NotFound("Could not find the user");
            }
            if (ModelState.IsValid)
            {
                return View(userModel);
            }

<<<<<<< HEAD
            return Ok();

        }
=======
            return View();
            }
>>>>>>> d5ff2831f927c2a67a0908f5638a89c91e48a35b

    }
}