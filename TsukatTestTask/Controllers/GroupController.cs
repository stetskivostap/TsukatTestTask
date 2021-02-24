using BuisnessLogicLayer.Interfaces;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace TsukatTestTask.Controllers
{
    [ApiController]
    [Route("api/groups")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupsService;
        public GroupController(IGroupService GroupsService)
        {
            _groupsService = GroupsService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_groupsService.GetAllGroups());
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(Group Group)
        {
            await _groupsService.UpdateGroup(Group.Id, Group);
            return Ok(Group);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add(string Group)
        {
            await _groupsService.AddGroup(Group);
            return Ok(Group);
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _groupsService.DeleteGroup(id);
            return Ok();
        }
    }
}
