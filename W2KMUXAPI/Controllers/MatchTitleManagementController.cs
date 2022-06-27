using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;
using W2KMUXBAL.Services;
using W2KMUXDAL.Models;

namespace W2KMUXAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MatchTitleManagementController : ControllerBase
    {
        private readonly IMatchTitleManagementBAL _matchTitleManagementBAL;

        public MatchTitleManagementController(IMatchTitleManagementBAL matchTitleManagementBAL)
        {
            _matchTitleManagementBAL = matchTitleManagementBAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetMatchTitleManagementList()
        {
            var result = await _matchTitleManagementBAL.GetMatchTitleManagementList();
            if (result.Count() > 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("No data found!");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMatchTitleManagement(string id)
        {
            var result = await _matchTitleManagementBAL.GetMatchTitleManagement(new Guid(id));
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
        public async Task<IActionResult> AddMatchTitleManagement(MatchTitleManagementDto matchTitleManagementDto)
        {
            var result = await _matchTitleManagementBAL.AddMatchTitleManagement(matchTitleManagementDto);
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
        public async Task<IActionResult> UpdateMatchTitleManagement(MatchTitleManagementDto matchTitleManagementDto)
        {
            var result = await _matchTitleManagementBAL.UpdateMatchTitleManagement(matchTitleManagementDto);
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
        public async Task<IActionResult> DeleteMatchTitleManagement(string id)
        {
            var result = await _matchTitleManagementBAL.DeleteMatchTitleManagement(new Guid(id));
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
