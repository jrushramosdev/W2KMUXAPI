using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Models;

namespace W2KMUXBAL.Services
{
    public interface IMatchTypeManagementBAL
    {
        Task<IEnumerable<MatchTypeManagementDto>> GetMatchTypeManagementList();
        Task<MatchTypeManagementDto> GetMatchTypeManagement(Guid id);
        Task<bool> AddMatchTypeManagement(MatchTypeManagementDto matchTypeManagementDto);
        Task<bool> UpdateMatchTypeManagement(MatchTypeManagementDto matchTypeManagementDto);
        Task<bool> DeleteMatchTypeManagement(Guid id);
    }
}
