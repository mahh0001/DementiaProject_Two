using DementiaProject_Two.Models.Account;
using DementiaProject_Two.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace DementiaProject_Two.Controllers
{
    [Route("[controller]/[action]")]
    public class EditController : Controller
    {
        public EditController(UserManager<IdentityUser> userman, IRepository repo)
        {
            Userman = userman;
            this.repo = repo;
        }
        private IRepository repo;

        public UserInformationModel UserInfo { get; set; }
        public UserManager<IdentityUser> Userman { get; }

      

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            var user = Userman.FindByEmailAsync(User.Identity.Name).Result;
            var userInformation = repo.Get(new Guid(user.Id));

            if(userInformation == null)
            {
                userInformation = new UserInformationModel() { Id = new Guid(user.Id) };
            }
            return View(userInformation);
        }
        [HttpPost]
        public IActionResult Update([FromForm, Bind(include: "FirstName, LastName, Gender, Id, ZipCode, Picture")]UserInformationModel userModel)
        {
           if(userModel == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            repo.Update(userModel);
            return RedirectToAction("Index");
        }

      
    }
}