using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Models;

namespace W2KMUXBAL.Services
{
    public interface IChampionshipManagementBAL
    {
        Task<IEnumerable<ChampionshipManagementDto>> GetChampionshipManagementList();
        Task<ChampionshipManagementDto> GetChampionshipManagement(Guid id);
        Task<bool> AddChampionshipManagement(ChampionshipManagementDto championshipManagementDto);
        Task<bool> UpdateChampionshipManagement(ChampionshipManagementDto championshipManagementDto);
        Task<bool> SoftDeleteChampionshipManagement(Guid id);
        Task<bool> DeleteChampionshipManagement(Guid id);

        Task<IEnumerable<ChampionsNestedDto>> GetChampionsNestedList();
    }
}
