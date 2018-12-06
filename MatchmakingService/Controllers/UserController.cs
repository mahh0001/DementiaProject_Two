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
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInfoRepository _repo;
        public UserController(IUserInfoRepository repo)
        {
            _repo = repo;
        }
        [HttpGet("{id}")]
        public IActionResult GetUser(Guid id)
        {
            UserInfo userInfo = _repo.GetInfoWithGuid(id); 
            if (userInfo == null)
            {
                return NotFound();
            }
            return Ok(userInfo);
        }
        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_repo.GetAll());
        }
    }
}