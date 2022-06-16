using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Models;

namespace W2KMUXBAL.Services
{
    public interface ITeamManagementBAL
    {
        Task<IEnumerable<TeamManagementDto>> GetTeamManagementList();
        Task<TeamManagementDto> GetTeamManagement(Guid id);
        Task<bool> AddTeamManagement(TeamManagementDto teamManagementDto);
        Task<bool> UpdateTeamManagement(TeamManagementDto teamManagementDto);
        Task<bool> SoftDeleteTeamManagement(Guid id);
        Task<bool> DeleteTeamManagement(Guid id);
    }
}
