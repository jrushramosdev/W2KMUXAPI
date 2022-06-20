using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using W2KMUXBAL.Services;
using W2KMUXDAL.Models;

namespace W2KMUXAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ChampionshipManagementController : ControllerBase
    {
        private readonly IChampionshipManagementBAL _championshipManagementBAL;
        public ChampionshipManagementController(IChampionshipManagementBAL championshipManagementBAL)
        {
            _championshipManagementBAL = championshipManagementBAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetChampionshipManagementList()
        {
            var result = await _championshipManagementBAL.GetChampionshipManagementList();
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
        public async Task<IActionResult> GetChampionshipManagement(string id)
        {
            var result = await _championshipManagementBAL.GetChampionshipManagement(new Guid(id));
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
        public async Task<IActionResult> AddChampionshipManagement(ChampionshipManagementDto championshipManagementDto)
        {
            var result = await _championshipManagementBAL.AddChampionshipManagement(championshipManagementDto);
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
        public async Task<IActionResult> UpdateChampionshipManagement(ChampionshipManagementDto championshipManagementDto)
        {
            var result = await _championshipManagementBAL.UpdateChampionshipManagement(championshipManagementDto);
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
        public async Task<IActionResult> SoftDeleteChampionshipManagement(string id)
        {
            var result = await _championshipManagementBAL.SoftDeleteChampionshipManagement(new Guid(id));
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
        public async Task<IActionResult> DeleteChampionshipManagement(string id)
        {
            var result = await _championshipManagementBAL.DeleteChampionshipManagement(new Guid(id));
            if (result == true)
            {
                return Ok("Successfully deleted!");
            }
            else
            {
                return BadRequest("No data deleted!");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetChampionsNestedList()
        {
            var result = await _championshipManagementBAL.GetChampionsNestedList();
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("No data found!");
            }
        }
    }
}
