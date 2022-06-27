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
    public class SuperstarController : ControllerBase
    {
        private readonly ISuperstarBAL _superstarBAL;

        public SuperstarController(ISuperstarBAL superstarBAL)
        {
            _superstarBAL = superstarBAL;
        }

        [HttpGet]
        public async Task<IActionResult> GetSuperstarList()
        {
            var result = await _superstarBAL.GetSuperstarList();
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
        public async Task<IActionResult> GetSuperstar(string id)
        {
            var result = await _superstarBAL.GetSuperstar(new Guid(id));
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
        public async Task<IActionResult> AddSuperstar(SuperstarDto superstarDto)
        { 
            var result = await _superstarBAL.AddSuperstar(superstarDto);
            if (result.Item1 == true)
            {
                return Ok("Successfully added new data!");
            }
            else
            {
                if (result.Item2 == "")
                {
                    return BadRequest();
                }
                else
                {
                    return BadRequest(result.Item2);
                }     
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSuperstar(SuperstarDto superstarDto)
        {
            var result = await _superstarBAL.UpdateSuperstar(superstarDto);
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
        public async Task<IActionResult> SoftDeleteSuperstar(string id)
        {
            var result = await _superstarBAL.SoftDeleteSuperstar(new Guid(id));
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
        public async Task<IActionResult> DeleteSuperstar(string id)
        {
            var result = await _superstarBAL.DeleteSuperstar(new Guid(id));
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
