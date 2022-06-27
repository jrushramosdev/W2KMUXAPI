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
    public class TeamHistoryController : ControllerBase
    {
        private readonly ITeamHistoryBAL _teamHistoryBAL;
        public TeamHistoryController(ITeamHistoryBAL teamHistoryBAL)
        {
            _teamHistoryBAL = teamHistoryBAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetTeamHistoryList()
        {
            var result = await _teamHistoryBAL.GetTeamHistoryList();
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
        public async Task<IActionResult> GetTeamHistoryListById(string id)
        {
            var result = await _teamHistoryBAL.GetTeamHistoryListById(new Guid(id));
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("No data found!");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteTeamHistory(string id)
        {
            var result = await _teamHistoryBAL.SoftDeleteTeamHistory(new Guid(id));
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
        public async Task<IActionResult> DeleteTeamHistory(string id)
        {
            var result = await _teamHistoryBAL.DeleteTeamHistory(new Guid(id));
            if (result == true)
            {
                return Ok("Successfully deleted!");
            }
            else
            {
                return BadRequest("No data deleted!");
            }
        }

        [HttpGet("{isactiveonly}")]
        public async Task<IActionResult> GetTeamHistoryNestedList(bool isactiveonly)
        {
            var result = await _teamHistoryBAL.GetTeamHistoryNestedList(isactiveonly);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("No data found!");
            }
        }

        //[HttpPost]
        //public async Task<IActionResult> UpdateTeamHistoryStatusList(TeamHistoryDto teamHistoryDto)
        //{
        //    var superstarisactive = false;
        //    var result = await _teamHistoryBAL.UpdateTeamHistoryStatusList(teamHistoryDto.SuperstarId, teamHistoryDto.TeamId, superstarisactive);

        //    if (result == true)
        //    {
        //        return Ok("Successfully added new data!");
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}
    }
}
