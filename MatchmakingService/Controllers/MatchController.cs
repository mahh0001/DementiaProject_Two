using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchmakingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        public MatchController()
        {

        }


        public IActionResult CheckIf;

        public IActionResult RegisterUserChoice()
        {
            return null;
        }
    }
}