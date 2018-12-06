using DementiaProject_Two.Models.Account;
using DementiaProject_Two.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DementiaProject_Two.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using AutoMapper;

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
            var userInformation = repo.GetUserInfoByEmail(user.Email);

            if(userInformation == null)
            {
                userInformation = new UserInformationModel() { Email = user.Email };
            }
            var userToMap = Mapper.Map<UserViewModel>(userInformation);
            return View(userToMap);
        }

        [HttpPost]
        public IActionResult Update([FromForm, Bind(include: "FirstName, LastName, GenderType, Id, ZipCode, Email, Age")] UserViewModel userModel)
        {
           if(userModel == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var info = repo.GetUserInfoByEmail(userModel.Email);


            if (info == null)
            {
                var infoToMap = Mapper.Map<UserInformationModel>(info);
                repo.AddUserInfo(infoToMap);
            }
            else
            {
                info.Age = userModel.Age;
                info.FirstName = userModel.FirstName;
                info.LastName = userModel.LastName;
                info.ZipCode = userModel.ZipCode;
                info.Gender = userModel.GenderType.ToString();
                repo.Update(info);
            }
           
            return RedirectToAction("Index");
        }

      
    }
}