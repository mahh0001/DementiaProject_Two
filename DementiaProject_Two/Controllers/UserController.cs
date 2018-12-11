using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public UserManager<IdentityUser> UserManager { get; }

        public UserController(UserManager<IdentityUser> userManager, MatchmakingApi proxy)
        {
            UserManager = userManager;
            _proxy = proxy;
        }

        private string GetUserIdentity()
        {
            return UserManager.FindByEmailAsync(User.Identity.Name).Result.Id;
        }

        [HttpGet(Name = "Index")]
        public async Task<IActionResult> Index()
        {
            var userId = GetUserIdentity();
            var userInformation = await _proxy.GetEntityAsync<UserInfoDTO>($@"https://localhost:44375/api/user/{userId}");
            if (userInformation != null)
            {
                return RedirectToAction("Update", "User");
            }
            return RedirectToAction("Add", "User");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            bool success = await _proxy.DeleteUser(Guid.Parse(GetUserIdentity()));
            if (success)
            {
                return RedirectToAction("Index", "Home");
            }
            return StatusCode(500);
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            var userInfoDto = await _proxy.GetEntityAsync<UserInfoDTO>($@"https://localhost:44375/api/user/{GetUserIdentity()}");
            var userInfo = Mapper.Map<UserModel>(userInfoDto);

            return View("Index", userInfo);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UserModel userModel)
        {
            bool success = false;
            if (userModel == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                success = await _proxy.UpdateUser(userModel); // bool?
            }
            if (success)
            {
                return RedirectToAction("Index");
            }
            return StatusCode(500);
        }

        [HttpGet]
        public IActionResult Add()
        {
            var model = new UserModel { IdentityFK = Guid.Parse(GetUserIdentity()) };
            return View("Index", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromForm] UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userInfo = Mapper.Map<UserInfoDTO>(userModel);
            userInfo.Gender = userModel.GenderType.ToString();
            bool success = await _proxy.AddUserInformation(userInfo);

            if (success)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return StatusCode(500);
            }
        }

        [HttpGet(Name = "GetUser")]
        public async Task<IActionResult> GetUser()
        {
            var userInformation = await _proxy.GetEntityAsync<UserInfoDTO>($@"https://localhost:44375/api/user/{GetUserIdentity()}");

            if (userInformation == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var userToMap = Mapper.Map<UserModel>(userInformation);
            return View(userToMap);
        }
    }
}