using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using W2KMUXBAL.Services;
using W2KMUXDAL.Models;

namespace W2KMUXAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PPVManagementController : Controller
    {
        private readonly IPPVManagementBAL _ppvManagementBAL;

        public PPVManagementController(IPPVManagementBAL ppvManagementBAL)
        {
            _ppvManagementBAL = ppvManagementBAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetPPVManagementList()
        {
            var result = await _ppvManagementBAL.GetPPVManagementList();
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
        public async Task<IActionResult> GetPPVManagement(string id)
        {
            var result = await _ppvManagementBAL.GetPPVManagement(new Guid(id));
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
        public async Task<IActionResult> AddPPVManagement(PPVManagementDto ppvManagementDto)
        {
            var result = await _ppvManagementBAL.AddPPVManagement(ppvManagementDto);
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
        public async Task<IActionResult> UpdatePPVManagement(PPVManagementDto ppvManagementDto)
        {
            var result = await _ppvManagementBAL.UpdatePPVManagement(ppvManagementDto);
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
        public async Task<IActionResult> SoftDeletePPVManagement(string id)
        {
            var result = await _ppvManagementBAL.SoftDeletePPVManagement(new Guid(id));
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
        public async Task<IActionResult> DeletePPVManagement(string id)
        {
            var result = await _ppvManagementBAL.DeletePPVManagement(new Guid(id));
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
