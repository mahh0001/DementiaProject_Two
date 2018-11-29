using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DementiaProject_Two.DataContexts;
using DementiaProject_Two.Migrations.UserInformation;
using DementiaProject_Two.Models.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DementiaProject_Two.Controllers
{
    [Route("[controller]")]
    public class UserInformationController : Controller
    {
        private UserInformationContext context;

        public UserInformationController(UserInformationContext context)
        {
            this.context = context;
        }

        [HttpGet("index")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserInformationModel userInfo, List<IFormFile> Picture)
        {
            foreach (var item in Picture)
            {
                if (item.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await item.CopyToAsync(stream);
                        userInfo.Picture = stream.ToArray();

                    }
                }
            ViewData["Picture"] = Convert.ToBase64String(userInfo.Picture);
            }
            context.UserInformations.Add(userInfo);
            context.SaveChanges();

            return View();
        }
    }
}