using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Models;

namespace W2KMUXBAL.Services
{
    public interface IMatchFormatManagementBAL
    {
        Task<IEnumerable<MatchFormatManagementDto>> GetMatchFormatManagementList();
        Task<MatchFormatManagementDto> GetMatchFormatManagement(Guid id);
        Task<bool> AddMatchFormatManagement(MatchFormatManagementDto matchFormatManagementDto);
        Task<bool> UpdateMatchFormatManagement(MatchFormatManagementDto matchFormatManagementDto);
        Task<bool> DeleteMatchFormatManagement(Guid id);
    }
}
