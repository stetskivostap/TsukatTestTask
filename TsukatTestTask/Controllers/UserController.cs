using BuisnessLogicLayer.Interfaces;
using BuisnessLogicLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TsukatTestTask.Entities;

namespace TsukatTestTask.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UserController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_usersService.GetAllUser());
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(User user)
        {
            await _usersService.UpdateUser(user.Id, user);
            return Ok(user);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(User user)
        {
            await _usersService.AddUser(user);
            return Ok(user);
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _usersService.DeleteUser(id);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult SignIn([FromBody] LoginModel login)
        {
            return Ok(_usersService.SignIn(login));
        }
    }
}
