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
    public class MatchTypeManagementBAL : IMatchTypeManagementBAL
    {
        private readonly IUnitOfWork unitOfWork;

        public MatchTypeManagementBAL(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<MatchTypeManagementDto>> GetMatchTypeManagementList()
        {
            var result = await unitOfWork.MatchTypeManagementRepository.GetMatchTypeManagementList();
            return result;
        }

        public async Task<MatchTypeManagementDto> GetMatchTypeManagement(Guid id)
        {
            var result = await unitOfWork.MatchTypeManagementRepository.GetMatchTypeManagement(id);
            return result;
        }

        public async Task<bool> AddMatchTypeManagement(MatchTypeManagementDto matchTypeManagementDto)
        {
            unitOfWork.MatchTypeManagementRepository.AddMatchTypeManagement(matchTypeManagementDto);
            return await unitOfWork.SaveAsync();
        }

        public async Task<bool> UpdateMatchTypeManagement(MatchTypeManagementDto matchTypeManagementDto)
        {
            unitOfWork.MatchTypeManagementRepository.UpdateMatchTypeManagement(matchTypeManagementDto);
            return await unitOfWork.SaveAsync();
        }

        public async Task<bool> DeleteMatchTypeManagement(Guid id)
        {
            unitOfWork.MatchTypeManagementRepository.DeleteMatchTypeManagement(id);
            return await unitOfWork.SaveAsync();
        }
    }
}
