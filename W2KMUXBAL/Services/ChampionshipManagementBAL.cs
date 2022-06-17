using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Data;
using W2KMUXDAL.Models;

namespace W2KMUXBAL.Services
{
    public class ChampionshipManagementBAL : IChampionshipManagementBAL
    {
        private readonly IUnitOfWork unitOfWork;

        public ChampionshipManagementBAL(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ChampionshipManagementDto>> GetChampionshipManagementList()
        {
            var result = await unitOfWork.ChampionshipManagementRepository.GetChampionshipManagementList();
            return result;
        }

        public async Task<ChampionshipManagementDto> GetChampionshipManagement(Guid id)
        {
            var result = await unitOfWork.ChampionshipManagementRepository.GetChampionshipManagement(id);
            return result;
        }

        public async Task<bool> AddChampionshipManagement(ChampionshipManagementDto championshipTypeManagementDto)
        {
            unitOfWork.ChampionshipManagementRepository.AddChampionshipManagement(championshipTypeManagementDto);
            return await unitOfWork.SaveAsync();
        }

        public async Task<bool> UpdateChampionshipManagement(ChampionshipManagementDto championshipTypeManagementDto)
        {
            unitOfWork.ChampionshipManagementRepository.UpdateChampionshipManagement(championshipTypeManagementDto);
            return await unitOfWork.SaveAsync();
        }

        public async Task<bool> SoftDeleteChampionshipManagement(Guid id)
        {
            unitOfWork.ChampionshipManagementRepository.SoftDeleteChampionshipManagement(id);
            return await unitOfWork.SaveAsync();
        }

        public async Task<bool> DeleteChampionshipManagement(Guid id)
        {
            unitOfWork.ChampionshipManagementRepository.DeleteChampionshipManagement(id);
            return await unitOfWork.SaveAsync();
        }
    }
}
