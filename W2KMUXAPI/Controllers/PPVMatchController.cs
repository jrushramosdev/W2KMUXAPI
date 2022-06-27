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
    public class PPVMatchController : ControllerBase
    {
        private readonly IPPVMatchBAL _ppvMatchBAL;

        public PPVMatchController(IPPVMatchBAL ppvMatchBAL)
        {
            _ppvMatchBAL = ppvMatchBAL;
        }

        [HttpGet("{ppvid}/{ppvcount}")]
        public async Task<IActionResult> GetPPVMatchNestedList(string ppvid, int ppvcount)
        {
            var result = await _ppvMatchBAL.GetPPVMatchNestedList(new Guid(ppvid), ppvcount);
            if (result.Count() > 0)
            {
                return Ok(result);
            }
            else
            {
                return NotFound("No data found!");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPPVMatchLatest()
        {
            var result = await _ppvMatchBAL.GetPPVMatchLatest();
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
