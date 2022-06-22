using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using W2KMUXBAL.Services;
using W2KMUXDAL.Models;

namespace W2KMUXAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MatchTypeManagementController : ControllerBase
    {
        private readonly IMatchTypeManagementBAL _matchTypeManagementBAL;

        public MatchTypeManagementController(IMatchTypeManagementBAL matchTypeManagementBAL)
        {
            _matchTypeManagementBAL = matchTypeManagementBAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetMatchTypeManagementList()
        {
            var result = await _matchTypeManagementBAL.GetMatchTypeManagementList();
            //return NotFound("No data found!"); // For test only
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
        public async Task<IActionResult> GetMatchTypeManagement(string id)
        {
            var result = await _matchTypeManagementBAL.GetMatchTypeManagement(new Guid(id));
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
        public async Task<IActionResult> AddMatchTypeManagement(MatchTypeManagementDto matchTypeManagementDto)
        {
            var result = await _matchTypeManagementBAL.AddMatchTypeManagement(matchTypeManagementDto);
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
        public async Task<IActionResult> UpdateMatchTypeManagement(MatchTypeManagementDto matchTypeManagementDto)
        {
            var result = await _matchTypeManagementBAL.UpdateMatchTypeManagement(matchTypeManagementDto);
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
        public async Task<IActionResult> DeleteMatchTypeManagement(string id)
        {
            var result = await _matchTypeManagementBAL.DeleteMatchTypeManagement(new Guid(id));
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
