using DementiaProject_Two.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using AutoMapper;
using DementiaProject_Two.Services;
using DementiaProject_Two.Models.DataTransferObjects;
using System.Threading.Tasks;
using DementiaProject_Two.Models.User;

namespace DementiaProject_Two.Controllers
{
    [Authorize]
    [Route("[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly MatchmakingApi _proxy;

        public UserController(UserManager<IdentityUser> userman, MatchmakingApi proxy)
        {
            UserManager = userman;
            _proxy = proxy;
        }

        public UserInformationModel UserInfo { get; set; }
        public UserManager<IdentityUser> UserManager { get; }

        [HttpGet(Name = "Index")]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            var user = UserManager.FindByEmailAsync(User.Identity.Name).Result;
            bool success = await _proxy.DeleteUser(Guid.Parse(user.Id));
            if (success)
            {
                return RedirectToAction("Index", "Home");
            }
            return StatusCode(500);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UserModel userModel)
        {
            if (userModel == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
               await _proxy.UpdateUser(userModel);
            }
            return RedirectToAction("Index");

        }

        [HttpGet(Name = "GetUser")]
        public async Task<IActionResult> GetUser()
        {
            var user = UserManager.FindByEmailAsync(User.Identity.Name).Result;
            var userInformation = await _proxy.GetEntityAsync<UserInfoDTO>($@"http://localhost:44375/api/user/{user.Id}");

            if (userInformation == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var userToMap = Mapper.Map<UserModel>(userInformation);
            return View(userToMap);
        }

    }
}