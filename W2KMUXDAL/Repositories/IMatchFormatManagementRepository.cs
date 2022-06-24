using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Models;

namespace W2KMUXDAL.Repositories
{
    public interface IMatchFormatManagementRepository
    {
        Task<IEnumerable<MatchFormatManagementDto>> GetMatchFormatManagementList();
        Task<MatchFormatManagementDto> GetMatchFormatManagement(Guid id);
        void AddMatchFormatManagement(MatchFormatManagementDto matchFormatManagementDto);
        void UpdateMatchFormatManagement(MatchFormatManagementDto matchFormatManagementDto);
        void DeleteMatchFormatManagement(Guid id);
    }
}
