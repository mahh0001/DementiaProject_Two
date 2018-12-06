using DementiaProject_Two.Models.Account;
using DementiaProject_Two.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DementiaProject_Two.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using AutoMapper;
using DementiaProject_Two.Connections;
using System.Threading.Tasks;
using DementiaProject_Two.Models.DataTransferObjects;

namespace DementiaProject_Two.Controllers
{
    [Route("[controller]/[action]")]
    public class EditController : Controller
    {
        public EditController(UserManager<IdentityUser> userManager)//, IRepository repo)
        {
            _userManager = userManager;
          //  this.repo = repo;
        }
        //private IRepository repo;

        //public UserInformationModel UserInfo { get; set; }
        public UserManager<IdentityUser> _userManager { get; }

        [Authorize]
        [HttpGet(Name = "Index")]
        public async Task<IActionResult> Index()
        {
            var user = _userManager.FindByEmailAsync(User.Identity.Name).Result;
            //var userInformation = repo.GetUserInfoByEmail(user.Email);

            var guid = Guid.Parse(user.Id);
            var userInformation = await MatchmakingApi.GetUserInformation(guid);

            //if(userInformation == null)
            //{
            //    userInformation = new UserInformationModel() { Email = user.Email };
            //}


            // -------------------------------------------------------------->> haven't mapped it yet.
            var userToMap = Mapper.Map<UserViewModel>(userInformation);
            return View(userToMap);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromForm, Bind(include: "FirstName, LastName, GenderType, Id, ZipCode, Email, Age")] UserViewModel userModel)
        {
           if(userModel == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            //var info = repo.GetUserInfoByEmail(User.Identity.Name);

            var guid = Guid.Parse(_userManager.FindByEmailAsync(User.Identity.Name).Result.Id);
            var info = await MatchmakingApi.GetUserInformation(guid); // weird naming 

            if (info == null)
            {
                var infoToMap = Mapper.Map<UserInfoDTO>(userModel);
                //repo.AddUserInfo(infoToMap);
                await MatchmakingApi.UpdateUserInformation(infoToMap);
                return RedirectToAction("Index");
            }
            else
            { 
                info = Mapper.Map<UserInfoDTO>(userModel);
                await MatchmakingApi.UpdateUserInformation(info);
            }
            return CreatedAtRoute("GetUser", info); //, new { id = info.Email}); <--- what was happening here? The GetUser method takes no params
            // Might have broken somehting here.
        }
        [HttpGet(Name = "GetUser")]
        public IActionResult GetUser()
        {
            return View();
        }

    }
}