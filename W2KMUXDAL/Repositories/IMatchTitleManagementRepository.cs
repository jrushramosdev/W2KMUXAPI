using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Models;

namespace W2KMUXDAL.Repositories
{
    public interface IMatchTitleManagementRepository
    {
        Task<IEnumerable<MatchTitleManagementDto>> GetMatchTitleManagementList();
        Task<MatchTitleManagementDto> GetMatchTitleManagement(Guid id);
        void AddMatchTitleManagement(MatchTitleManagementDto matchTitleManagementDto);
        void UpdateMatchTitleManagement(MatchTitleManagementDto matchTitleManagementDto);
        void DeleteMatchTitleManagement(Guid id);
    }
}
