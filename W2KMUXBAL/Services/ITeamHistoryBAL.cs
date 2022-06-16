using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Models;

namespace W2KMUXBAL.Services
{
    public interface ITeamHistoryBAL
    {
        Task<IEnumerable<TeamHistoryDto>> GetTeamHistoryList();
        Task<IEnumerable<TeamHistoryDto>> GetTeamHistoryListById(Guid superstarid);
        Task<TeamHistoryDto> GetTeamHistory(Guid id);
        Task<bool> AddTeamHistory(TeamHistoryDto superstarDto);
        Task<bool> UpdateTeamHistory(TeamHistoryDto superstarDto);
        Task<bool> SoftDeleteTeamHistory(Guid id);
        Task<bool> DeleteTeamHistory(Guid id);

        Task<IEnumerable<TeamHistoryNestedDto>> GetTeamHistoryNestedList(bool isactiveonly);
        Task<bool> UpdateTeamHistoryStatusList(Guid superstarid, Guid? teamid, bool superstarisactive);
    }
}
