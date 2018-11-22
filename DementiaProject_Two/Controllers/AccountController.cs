using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DementiaProject_Two.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}