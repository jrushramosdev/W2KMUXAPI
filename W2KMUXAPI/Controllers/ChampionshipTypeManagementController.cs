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
    public class ChampionshipTypeManagementController : ControllerBase
    {
        private readonly IChampionshipTypeManagementBAL _championshipTypeManagementBAL;
        public ChampionshipTypeManagementController(IChampionshipTypeManagementBAL championshipTypeManagementBAL)
        {
            _championshipTypeManagementBAL = championshipTypeManagementBAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetChampionshipTypeManagementList()
        {
            var result = await _championshipTypeManagementBAL.GetChampionshipTypeManagementList();
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
        public async Task<IActionResult> GetChampionshipTypeManagement(string id)
        {
            var result = await _championshipTypeManagementBAL.GetChampionshipTypeManagement(new Guid(id));
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
        public async Task<IActionResult> AddChampionshipTypeManagement(ChampionshipTypeManagementDto championshipTypeManagementDto)
        {
            var result = await _championshipTypeManagementBAL.AddChampionshipTypeManagement(championshipTypeManagementDto);
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
        public async Task<IActionResult> UpdateChampionshipTypeManagement(ChampionshipTypeManagementDto championshipTypeManagementDto)
        {
            var result = await _championshipTypeManagementBAL.UpdateChampionshipTypeManagement(championshipTypeManagementDto);
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
        public async Task<IActionResult> SoftDeleteChampionshipTypeManagement(string id)
        {
            var result = await _championshipTypeManagementBAL.SoftDeleteChampionshipTypeManagement(new Guid(id));
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
        public async Task<IActionResult> DeleteChampionshipTypeManagement(string id)
        {
            var result = await _championshipTypeManagementBAL.DeleteChampionshipTypeManagement(new Guid(id));
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
