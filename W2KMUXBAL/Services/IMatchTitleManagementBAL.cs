using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Models;

namespace W2KMUXBAL.Services
{
    public interface IMatchTitleManagementBAL
    {
        Task<IEnumerable<MatchTitleManagementDto>> GetMatchTitleManagementList();
        Task<MatchTitleManagementDto> GetMatchTitleManagement(Guid id);
        Task<bool> AddMatchTitleManagement(MatchTitleManagementDto matchTitleManagementDto);
        Task<bool> UpdateMatchTitleManagement(MatchTitleManagementDto matchTitleManagementDto);
        Task<bool> DeleteMatchTitleManagement(Guid id);
    }
}
