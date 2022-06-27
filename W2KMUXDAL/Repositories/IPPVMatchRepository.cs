using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Models;

namespace W2KMUXDAL.Repositories
{
    public interface IPPVMatchRepository
    {
        Task<IEnumerable<PPVMatchDto>> GetPPVMatchList(Guid ppvid, int ppvcount);
        Task<PPVMatchLatestDto> GetPPVMatchLatest();
        Task<PPVMatchLatestDto> GetPPVMatchDefault();
    }
}
