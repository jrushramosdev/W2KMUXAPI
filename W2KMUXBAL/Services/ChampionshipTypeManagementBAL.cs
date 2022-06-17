using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Data;
using W2KMUXDAL.Models;

namespace W2KMUXBAL.Services
{
    public class ChampionshipTypeManagementBAL : IChampionshipTypeManagementBAL
    {
        private readonly IUnitOfWork unitOfWork;

        public ChampionshipTypeManagementBAL(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ChampionshipTypeManagementDto>> GetChampionshipTypeManagementList()
        {
            var result = await unitOfWork.ChampionshipTypeManagementRepository.GetChampionshipTypeManagementList();
            return result;
        }

        public async Task<ChampionshipTypeManagementDto> GetChampionshipTypeManagement(Guid id)
        {
            var result = await unitOfWork.ChampionshipTypeManagementRepository.GetChampionshipTypeManagement(id);
            return result;
        }

        public async Task<bool> AddChampionshipTypeManagement(ChampionshipTypeManagementDto championshipTypeManagementDto)
        {
            unitOfWork.ChampionshipTypeManagementRepository.AddChampionshipTypeManagement(championshipTypeManagementDto);
            return await unitOfWork.SaveAsync();
        }

        public async Task<bool> UpdateChampionshipTypeManagement(ChampionshipTypeManagementDto championshipTypeManagementDto)
        {
            unitOfWork.ChampionshipTypeManagementRepository.UpdateChampionshipTypeManagement(championshipTypeManagementDto);
            return await unitOfWork.SaveAsync();
        }

        public async Task<bool> SoftDeleteChampionshipTypeManagement(Guid id)
        {
            unitOfWork.ChampionshipTypeManagementRepository.SoftDeleteChampionshipTypeManagement(id);
            return await unitOfWork.SaveAsync();
        }

        public async Task<bool> DeleteChampionshipTypeManagement(Guid id)
        {
            unitOfWork.ChampionshipTypeManagementRepository.DeleteChampionshipTypeManagement(id);
            return await unitOfWork.SaveAsync();
        }
    }
}
