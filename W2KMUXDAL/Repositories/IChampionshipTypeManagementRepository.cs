using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Models;

namespace W2KMUXDAL.Repositories
{
    public interface IChampionshipTypeManagementRepository
    {
        Task<IEnumerable<ChampionshipTypeManagementDto>> GetChampionshipTypeManagementList();
        Task<ChampionshipTypeManagementDto> GetChampionshipTypeManagement(Guid id);
        void AddChampionshipTypeManagement(ChampionshipTypeManagementDto championshipTypeManagementDto);
        void UpdateChampionshipTypeManagement(ChampionshipTypeManagementDto championshipTypeManagementDto);
        void SoftDeleteChampionshipTypeManagement(Guid id);
        void DeleteChampionshipTypeManagement(Guid id);
    }
}
