using System.Collections.Generic;
using DementiaProject_Two.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace DementiaProject_Two.Controllers
{
    [Route("[controller]")]
    public class ProfileController : Controller
    {
        public ProfileController(){ }

        [Authorize] 
        public IActionResult Index()
        {
            

            return View();   
        }

        [HttpPost]
        [Authorize]
        public ActionResult EditProfil([Bind(include:"ID, FirstName, LastName, Gender, Id, ZipCode")] UserInfoViewModel userModel)
        {
            if (userModel == null)
            {
                return NotFound("Could not find the user");
            }
            if (!ModelState.IsValid)
            {
                RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

    }
}