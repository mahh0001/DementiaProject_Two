using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchmakingService.Models;
using MatchmakingService.Models.DataTransferObjects;
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

        [HttpPost]
        [Route("getmatch")]
        // look into making all dis shit asyncronous rsum
        public ActionResult<UserInfo> GetMatch(Guid currentUser)
        {
            var user = _repo.FindRandomUser(currentUser);
            return user;
        }

        [HttpPost]
        [Route("savematch")]
        public ActionResult<bool> SaveMatch(MatchDTO matchDto)
        {
            return _repo.SaveMatchChoice(matchDto.User1, matchDto.User2, matchDto.Match);
        }


        //public IActionResult CheckIf()

        public IActionResult RegisterUserChoice()
        {
            return null;
        }
    }
}