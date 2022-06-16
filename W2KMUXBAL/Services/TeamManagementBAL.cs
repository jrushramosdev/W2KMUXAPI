using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Repositories;
using W2KMUXDAL.Data;
using W2KMUXDAL.Models;

namespace W2KMUXBAL.Services
{
    public class TeamManagementBAL : ITeamManagementBAL
    {
        private readonly IUnitOfWork unitOfWork;

        public TeamManagementBAL(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TeamManagementDto>> GetTeamManagementList()
        {
            var result = await unitOfWork.TeamManagementRepository.GetTeamManagementList();
            return result;
        }

        public async Task<TeamManagementDto> GetTeamManagement(Guid id)
        {
            var result = await unitOfWork.TeamManagementRepository.GetTeamManagement(id);
            return result;
        }

        public async Task<bool> AddTeamManagement(TeamManagementDto teamManagementDto)
        {
            unitOfWork.TeamManagementRepository.AddTeamManagement(teamManagementDto);
            return await unitOfWork.SaveAsync();
        }

        public async Task<bool> UpdateTeamManagement(TeamManagementDto teamManagementDto)
        {
            unitOfWork.TeamManagementRepository.UpdateTeamManagement(teamManagementDto);
            return await unitOfWork.SaveAsync();
        }

        public async Task<bool> SoftDeleteTeamManagement(Guid id)
        {
            unitOfWork.TeamManagementRepository.SoftDeleteTeamManagement(id);
            return await unitOfWork.SaveAsync();
        }

        public async Task<bool> DeleteTeamManagement(Guid id)
        {
            unitOfWork.TeamManagementRepository.DeleteTeamManagement(id);
            return await unitOfWork.SaveAsync();
        }
    }
}
