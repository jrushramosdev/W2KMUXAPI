using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using W2KMUXBAL.Services;
using W2KMUXDAL.Models;

namespace W2KMUXAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ShowManagementController : ControllerBase
    {
        private readonly IShowManagementBAL _showManagementBAL;

        public ShowManagementController(IShowManagementBAL showManagementBAL)
        {
            _showManagementBAL = showManagementBAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetShowManagementList()
        {
            var result = await _showManagementBAL.GetShowManagementList();
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
        public async Task<IActionResult> GetShowManagement(string id)
        {
            var result = await _showManagementBAL.GetShowManagement(new Guid(id));
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
        public async Task<IActionResult> AddShowManagement(ShowManagementDto showManagementDto)
        {
            var result = await _showManagementBAL.AddShowManagement(showManagementDto);
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
        public async Task<IActionResult> UpdateShowManagement(ShowManagementDto showManagementDto)
        {
            var result = await _showManagementBAL.UpdateShowManagement(showManagementDto);
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
        public async Task<IActionResult> SoftDeleteShowManagement(string id)
        {
            var result = await _showManagementBAL.SoftDeleteShowManagement(new Guid(id));
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
        public async Task<IActionResult> DeleteShowManagement(string id)
        {
            var result = await _showManagementBAL.DeleteShowManagement(new Guid(id));
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
