using System;
using System.IO;
using System.Threading.Tasks;
using DementiaProject_Two.DataContexts;
using DementiaProject_Two.Models.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DementiaProject_Two.Controllers
{

    [Route("[controller]/[action]")]
    public class UserInformationController : Controller
    {
        private UserInformationContext _context;

        public UserInformationController(UserInformationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserInformationModel userInfo, IFormFile picture)
        {
            //For saving a picture in the database
            using (MemoryStream stream = new MemoryStream())
            {
                await picture.CopyToAsync(stream);
                userInfo.Picture = stream.ToArray();
            
                
                ViewData["Picture"] = Convert.ToBase64String(userInfo.Picture);
            }

            _context.UserInformations.Add(userInfo);
            _context.SaveChanges();


            if (ModelState.IsValid)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                return View();
            }
        }
    }
}