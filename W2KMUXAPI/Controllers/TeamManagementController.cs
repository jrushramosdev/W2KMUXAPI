using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using W2KMUXBAL.Services;
using W2KMUXDAL.Models;

namespace W2KMUXAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TeamManagementController : ControllerBase
    {
        private readonly ITeamManagementBAL _teamManagementBAL;

        public TeamManagementController(ITeamManagementBAL teamManagementBAL)
        {
            _teamManagementBAL = teamManagementBAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeamManagementList()
        {
            var result = await _teamManagementBAL.GetTeamManagementList();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("No data found!");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTeamManagement(string id)
        {
            var result = await _teamManagementBAL.GetTeamManagement(new Guid(id));
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("No data found!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddTeamManagement(TeamManagementDto teamManagementDto)
        {
            var result = await _teamManagementBAL.AddTeamManagement(teamManagementDto);
            if (result == true)
            {
                return Ok("Successfully added new data!");
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTeamManagement(TeamManagementDto teamManagementDto)
        {
            var result = await _teamManagementBAL.UpdateTeamManagement(teamManagementDto);
            if (result == true)
            {
                return Ok("Your changes have been successfully updated!");
            }
            else
            {
                return BadRequest("Your changes couldn't updated, Please try again");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteTeamManagement(string id)
        {
            var result = await _teamManagementBAL.SoftDeleteTeamManagement(new Guid(id));
            if (result == true)
            {
                return Ok("Successfully deleted!");
            }
            else
            {
                return BadRequest("No data deleted!");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeamManagement(string id)
        {
            var result = await _teamManagementBAL.DeleteTeamManagement(new Guid(id));
            if (result == true)
            {
                return Ok("Successfully deleted!");
            }
            else
            {
                return BadRequest("No data deleted!");
            }
        }
    }
}
