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
    public class MatchFormatManagementBAL : IMatchFormatManagementBAL
    {
        private readonly IUnitOfWork unitOfWork;

        public MatchFormatManagementBAL(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<MatchFormatManagementDto>> GetMatchFormatManagementList()
        {
            var result = await unitOfWork.MatchFormatManagementRepository.GetMatchFormatManagementList();
            return result;
        }

        public async Task<MatchFormatManagementDto> GetMatchFormatManagement(Guid id)
        {
            var result = await unitOfWork.MatchFormatManagementRepository.GetMatchFormatManagement(id);
            return result;
        }

        public async Task<bool> AddMatchFormatManagement(MatchFormatManagementDto matchFormatManagementDto)
        {
            unitOfWork.MatchFormatManagementRepository.AddMatchFormatManagement(matchFormatManagementDto);
            return await unitOfWork.SaveAsync();
        }

        public async Task<bool> UpdateMatchFormatManagement(MatchFormatManagementDto matchFormatManagementDto)
        {
            unitOfWork.MatchFormatManagementRepository.UpdateMatchFormatManagement(matchFormatManagementDto);
            return await unitOfWork.SaveAsync();
        }

        public async Task<bool> DeleteMatchFormatManagement(Guid id)
        {
            unitOfWork.MatchFormatManagementRepository.DeleteMatchFormatManagement(id);
            return await unitOfWork.SaveAsync();
        }
    }
}
