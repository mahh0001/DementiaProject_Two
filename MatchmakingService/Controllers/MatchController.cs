using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchmakingService.Models;
using MatchmakingService.Services.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MatchmakingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        IUserMatchRepository _repo;
        public MatchController(IUserMatchRepository repo)
        {
            _repo = repo;
        }

        public async Task<ActionResult<UserInfo>> GetMatch()
        {
            var user = _repo.
        }


        //public IActionResult CheckIf()

        public IActionResult RegisterUserChoice()
        {
            return null;
        }
    }
}