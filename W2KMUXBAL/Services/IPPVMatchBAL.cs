using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Models;

namespace W2KMUXBAL.Services
{
    public interface IPPVMatchBAL
    {
        Task<IEnumerable<PPVMatchNestedDto>> GetPPVMatchNestedList(Guid ppvid, int ppvcount);
        Task<PPVMatchLatestDto> GetPPVMatchLatest();
        Task<bool> AddPPVMatch(PPVMatchNestedDto ppvMatchNestedDto);
        Task<bool> DeletePPVMatch(Guid id);
    }
}
