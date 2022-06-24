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
    public class MatchFormatManagementController : ControllerBase
    {
        private readonly IMatchFormatManagementBAL _matchFormatManagementBAL;

        public MatchFormatManagementController(IMatchFormatManagementBAL matchFormatManagementBAL)
        {
            _matchFormatManagementBAL = matchFormatManagementBAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetMatchFormatManagementList()
        {
            var result = await _matchFormatManagementBAL.GetMatchFormatManagementList();
            //return NotFound("No data found!"); // For test only
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
        public async Task<IActionResult> GetMatchFormatManagement(string id)
        {
            var result = await _matchFormatManagementBAL.GetMatchFormatManagement(new Guid(id));
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
        public async Task<IActionResult> AddMatchFormatManagement(MatchFormatManagementDto matchFormatManagementDto)
        {
            var result = await _matchFormatManagementBAL.AddMatchFormatManagement(matchFormatManagementDto);
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
        public async Task<IActionResult> UpdateMatchFormatManagement(MatchFormatManagementDto matchFormatManagementDto)
        {
            var result = await _matchFormatManagementBAL.UpdateMatchFormatManagement(matchFormatManagementDto);
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
        public async Task<IActionResult> DeleteMatchFormatManagement(string id)
        {
            var result = await _matchFormatManagementBAL.DeleteMatchFormatManagement(new Guid(id));
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
