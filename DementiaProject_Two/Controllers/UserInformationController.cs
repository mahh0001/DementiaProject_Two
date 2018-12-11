//using System;
//using System.IO;
//using System.Threading.Tasks;
//using DementiaProject_Two.DataContexts;
//using DementiaProject_Two.Models.Account;
//using DementiaProject_Two.Models.DataTransferObjects;
//using DementiaProject_Two.Services;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace DementiaProject_Two.Controllers
//{

//    [Route("[controller]/[action]")]
//    public class UserInformationController : Controller
//    {
//        private MatchmakingApi _api;

//        public UserInformationController(MatchmakingApi matchApi)
//        {
//            _api = matchApi;
//        }

//        [HttpGet]
//        public IActionResult Index()
//        {
//            return View();
//        }
//        [HttpPost]
//        public async Task<IActionResult> Index(UserInformationModel userInfo, IFormFile picture)
//        {

//            _api.UserInformations.Add(userInfo);
//            _api.SaveChanges();


//            if (ModelState.IsValid)
//            {
//                return RedirectToAction("Login", "Account");
//            }
//            else
//            {
//                return View();
//            }
//        }
//    }
//}