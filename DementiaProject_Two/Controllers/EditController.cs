using DementiaProject_Two.Models.Account;
using DementiaProject_Two.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace DementiaProject_Two.Controllers
{
    public class EditController : Controller
    {
        public EditController(UserManager<IdentityUser> userman)
        {
            Userman = userman;
        }
        private IRepository repo;

        public UserInformationModel UserInfo { get; set; }
        public UserManager<IdentityUser> Userman { get; }

        public EditController(IRepository repo)
        {
            this.repo = repo;
        }
        [HttpGet("")]
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
        public IActionResult Update([FromForm]UserInformationModel userModel)
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