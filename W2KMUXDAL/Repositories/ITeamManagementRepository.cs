using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Models;

namespace W2KMUXDAL.Repositories
{
    public interface ITeamManagementRepository
    {
        Task<IEnumerable<TeamManagementDto>> GetTeamManagementList();
        Task<TeamManagementDto> GetTeamManagement(Guid id);
        void AddTeamManagement(TeamManagementDto teamManagementDto);
        void UpdateTeamManagement(TeamManagementDto teamManagementDto);
        void SoftDeleteTeamManagement(Guid id);
        void DeleteTeamManagement(Guid id);
    }
}
