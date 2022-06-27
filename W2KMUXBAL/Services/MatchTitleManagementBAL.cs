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
    public class MatchTitleManagementBAL : IMatchTitleManagementBAL
    {
        private readonly IUnitOfWork unitOfWork;

        public MatchTitleManagementBAL(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<MatchTitleManagementDto>> GetMatchTitleManagementList()
        {
            var result = await unitOfWork.MatchTitleManagementRepository.GetMatchTitleManagementList();
            return result;
        }

        public async Task<MatchTitleManagementDto> GetMatchTitleManagement(Guid id)
        {
            var result = await unitOfWork.MatchTitleManagementRepository.GetMatchTitleManagement(id);
            return result;
        }

        public async Task<bool> AddMatchTitleManagement(MatchTitleManagementDto matchTitleManagementDto)
        {
            unitOfWork.MatchTitleManagementRepository.AddMatchTitleManagement(matchTitleManagementDto);
            return await unitOfWork.SaveAsync();
        }

        public async Task<bool> UpdateMatchTitleManagement(MatchTitleManagementDto matchTitleManagementDto)
        {
            unitOfWork.MatchTitleManagementRepository.UpdateMatchTitleManagement(matchTitleManagementDto);
            return await unitOfWork.SaveAsync();
        }

        public async Task<bool> DeleteMatchTitleManagement(Guid id)
        {
            unitOfWork.MatchTitleManagementRepository.DeleteMatchTitleManagement(id);
            return await unitOfWork.SaveAsync();
        }
    }
}
