using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Models;

namespace W2KMUXDAL.Repositories
{
    public interface IMatchTypeManagementRepository
    {
        Task<IEnumerable<MatchTypeManagementDto>> GetMatchTypeManagementList();
        Task<MatchTypeManagementDto> GetMatchTypeManagement(Guid id);
        void AddMatchTypeManagement(MatchTypeManagementDto matchTypeManagementDto);
        void UpdateMatchTypeManagement(MatchTypeManagementDto matchTypeManagementDto);
        void DeleteMatchTypeManagement(Guid id);
    }
}
