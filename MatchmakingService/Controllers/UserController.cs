using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MatchmakingService.Models;
using MatchmakingService.Models.DataTransferObjects;
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

        [HttpPost("add")]
        public IActionResult AddUser([FromBody] UserInfo user)
        {
            _repo.Add(user);
            _repo.SaveChanges();
            return Ok(new { succes = true });
        }
        //[HttpDelete]
        //public IActionResult EditUser([FromBody] UserInfo user)
        //{

        //}
        [HttpPut("edit")]
        public IActionResult UpdateUser([FromBody]UserInfoDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            UserInfo userToUpdate = _repo.GetInfoWithGuid(user.IdentityFK);
            userToUpdate = Mapper.Map<UserInfo>(user);
            _repo.SaveChanges();
            return Accepted();
        }
    }
}