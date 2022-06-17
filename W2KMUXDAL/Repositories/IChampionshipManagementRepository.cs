using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Models;

namespace W2KMUXDAL.Repositories
{
    public interface IChampionshipManagementRepository
    {
        Task<IEnumerable<ChampionshipManagementDto>> GetChampionshipManagementList();
        Task<ChampionshipManagementDto> GetChampionshipManagement(Guid id);
        Task<ChampionshipManagementDto> GetChampionshipManagementBySuperstarId(Guid superstarid);
        void AddChampionshipManagement(ChampionshipManagementDto championshipManagementDto);
        void UpdateChampionshipManagement(ChampionshipManagementDto championshipManagementDto);
        void SoftDeleteChampionshipManagement(Guid id);
        void DeleteChampionshipManagement(Guid id);
    }
}
