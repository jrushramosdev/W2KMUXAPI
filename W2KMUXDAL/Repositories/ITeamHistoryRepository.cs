using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Models;

namespace W2KMUXDAL.Repositories
{
    public interface ITeamHistoryRepository
    {
        //Task<IEnumerable<TeamHistoryNestedDto>> GetTeamHistoryNestedList();
        Task<IEnumerable<TeamHistoryDto>> GetTeamHistoryList();
        Task<IEnumerable<TeamHistoryDto>> GetTeamHistoryListBySuperstarId(Guid superstarid);
        Task<IEnumerable<TeamHistoryDto>> GetTeamHistoryListByTeamId(Guid teamid);
        Task<TeamHistoryDto> GetTeamHistory(Guid id);
        void AddTeamHistory(TeamHistoryDto teamHistoryDto);
        void UpdateTeamHistory(TeamHistoryDto teamHistoryDto);
        void UpdateTeamHistoryStatusList(Guid superstarid, bool isactive);
        void SoftDeleteTeamHistory(Guid id);
        void DeleteTeamHistory(Guid id);
    }
}
