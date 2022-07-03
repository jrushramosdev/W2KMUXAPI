using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Data.Models;
using W2KMUXDAL.Models;

namespace W2KMUXDAL.Repositories
{
    public interface IPPVMatchRepository
    {
        #region GET
        Task<IEnumerable<PPVMatchNestedDto>> GetPPVMatchList(Guid ppvid, int ppvcount);
        Task<PPVMatchLatestDto> GetPPVMatchLatest();
        Task<PPVMatchLatestDto> GetPPVMatchDefault();
        Task<IEnumerable<PPVMatchChampionshipDto>> GetPPVMatchChampionshipList(Guid ppvmatchid);
        Task<IEnumerable<PPVMatchTeamDto>> GetPPVMatchTeamList(Guid ppvmatchid);
        Task<IEnumerable<PPVMatchParticipantDto>> GetPPVMatchParticipantList(Guid ppvmatchteamid);
        #endregion

        #region ADD
        PPVMatch AddPPVMatch(PPVMatchNestedDto ppvMatchNestedDto);
        void AddPPVMatchChampionship(PPVMatchChampionshipDto ppvMatchChampionshipDto);
        PPVMatchTeam AddPPVMatchTeam(PPVMatchTeamDto ppvMatchTeamDto);
        void AddPPVMatchParticipant(PPVMatchParticipantDto ppvMatchParticipantDto);
        #endregion

        #region DELETE
        void DeletePPVMatch(Guid id);
        void DeletePPVMatchChampionship(Guid ppvmatchid);
        void DeletePPVMatchTeam(Guid ppvmatchid);
        void DeletePPVMatchParticipant(Guid ppvmatchteamid);
        #endregion
    }
}
