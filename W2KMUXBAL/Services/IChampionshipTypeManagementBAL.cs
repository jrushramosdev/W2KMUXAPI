using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Models;

namespace W2KMUXBAL.Services
{
    public interface IChampionshipTypeManagementBAL
    {
        Task<IEnumerable<ChampionshipTypeManagementDto>> GetChampionshipTypeManagementList();
        Task<ChampionshipTypeManagementDto> GetChampionshipTypeManagement(Guid id);
        Task<bool> AddChampionshipTypeManagement(ChampionshipTypeManagementDto ppvManagementDto);
        Task<bool> UpdateChampionshipTypeManagement(ChampionshipTypeManagementDto ppvManagementDto);
        Task<bool> SoftDeleteChampionshipTypeManagement(Guid id);
        Task<bool> DeleteChampionshipTypeManagement(Guid id);
    }
}
