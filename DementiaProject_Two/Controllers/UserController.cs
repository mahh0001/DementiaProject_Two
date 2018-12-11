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

        [Authorize]
        [HttpGet(Name = "Index")]
        public async Task<IActionResult> Index()
        {
            var user = UserManager.FindByEmailAsync(User.Identity.Name).Result;
            var userInformation = await _proxy.GetEntityAsync<UserInfoDTO>($@"http://localhost:44375/api/user/{user.Id}");

            if(userInformation == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var userToMap = Mapper.Map<UserModel>(userInformation);
            return View(userToMap);
        }

        [HttpPost]
        public IActionResult Update([FromForm] UserModel userModel)
        {
            if (userModel == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _proxy.UpdateUser(userModel);
            }
            return RedirectToAction("Index");

        }
        [HttpGet(Name = "GetUser")]
        public IActionResult GetUser()
        {
            return View();
        }

    }
}