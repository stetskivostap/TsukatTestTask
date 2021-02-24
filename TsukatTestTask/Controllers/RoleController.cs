using BuisnessLogicLayer.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TsukatTestTask.Entities;

namespace TsukatTestTask.Controllers
{
    [ApiController]
    [Route("api/Roles")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _rolesService;
        public RoleController(IRoleService RolesService)
        {
            _rolesService = RolesService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_rolesService.GetAllRoles());
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(Role role)
        {
            await _rolesService.UpdateRole(role.Id, role);
            return Ok(role);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(string role)
        {
            await _rolesService.AddRole(role);
            return Ok(role);
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _rolesService.DeleteRole(id);
            return Ok();
        }
    }
}
