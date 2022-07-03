using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using W2KMUXDAL.Data;
using W2KMUXDAL.Data.Models;
using W2KMUXDAL.Models;

namespace W2KMUXDAL.Repositories
{
    public class PPVMatchRepository : IPPVMatchRepository
    {
        private readonly W2KMUXContext _context;

        public PPVMatchRepository(W2KMUXContext context)
        {
            _context = context;
        }

        #region GET
        public async Task<IEnumerable<PPVMatchDto>> GetPPVMatchList(Guid ppvid, int ppvcount)
        {
            List<PPVMatchDto> ppvMatchDto = new List<PPVMatchDto>();

            ppvMatchDto = await (from ppvmatch in _context.PPVMatch
                                where ppvmatch.PPVMatchId == ppvid
                                where ppvmatch.PPVMatchCount == ppvcount
                                orderby ppvmatch.PPVMatchOrder
                                select new PPVMatchDto
                                {
                                    PPVMatchId = ppvmatch.PPVMatchId,
                                    PPVMatchName = ppvmatch.PPVMatchName,
                                    PPVMatchCount = ppvmatch.PPVMatchCount,
                                    PPVMatchOrder = ppvmatch.PPVMatchOrder,
                                    PPVId = ppvmatch.PPVMatchId,
                                    PPVName = ppvmatch.Ppv.PPVName,
                                    ShowId = ppvmatch.ShowId,
                                    ShowName = ppvmatch.Show.ShowName,
                                    MatchTitleId = ppvmatch.MatchTitleId,
                                    MatchFormatId = ppvmatch.MatchFormatId,
                                    IsDone = ppvmatch.isDone
                                }).ToListAsync();

            return ppvMatchDto;
        }

        public async Task<PPVMatchLatestDto> GetPPVMatchLatest()
        {
            PPVMatchLatestDto ppvMatchLatestDto = new PPVMatchLatestDto();

            ppvMatchLatestDto = await (from ppvmatch in _context.PPVMatch
                                     where ppvmatch.isDone == true
                                     orderby ppvmatch.PPVMatchCount, ppvmatch.Ppv.PPVOrder descending
                                     select new PPVMatchLatestDto
                                     {
                                        PPVMatchCount = ppvmatch.PPVMatchCount,
                                        PPVId = ppvmatch.PPVMatchId,
                                        PPVName = ppvmatch.Ppv.PPVName,
                                        IsDone = ppvmatch.isDone
                                     }).FirstOrDefaultAsync();

            return ppvMatchLatestDto;
        }

        public async Task<PPVMatchLatestDto> GetPPVMatchDefault()
        {
            PPVMatchLatestDto ppvMatchLatestDto = new PPVMatchLatestDto();

            ppvMatchLatestDto = await (from ppv in _context.Ppvs
                                       orderby ppv.PPVOrder
                                       select new PPVMatchLatestDto
                                       {
                                           PPVMatchCount = 1,
                                           PPVId = ppv.PPVId,
                                           PPVName = ppv.PPVName,
                                           IsDone = false
                                       }).FirstOrDefaultAsync();

            return ppvMatchLatestDto;
        }

        public async Task<IEnumerable<PPVMatchChampionshipDto>> GetPPVMatchChampionshipList(Guid ppvmatchid)
        {
            List<PPVMatchChampionshipDto> ppvMatchChampionshipDto = new List<PPVMatchChampionshipDto>();

            ppvMatchChampionshipDto = await (from ppvmatchchampionship in _context.PPVMatchChampionships
                                             where ppvmatchchampionship.PPVMatchId == ppvmatchid
                                             select new PPVMatchChampionshipDto
                                             {
                                                 PPVMatchChampionshipId = ppvmatchchampionship.PPVMatchChampionshipId,
                                                 PPVMatchId = ppvmatchchampionship.PPVMatchId,
                                                 ChampionshipId = ppvmatchchampionship.ChampionshipId,
                                                 ChampionshipName = ppvmatchchampionship.Championship.ChampionshipName
                                             }).ToListAsync();

            return ppvMatchChampionshipDto;
        }
        #endregion

        #region ADD
        public PPVMatch AddPPVMatch(PPVMatchNestedDto ppvMatchNestedDto)
        {
            int ppvmatchorder = 1;
            var ppvmatchcheck = _context.PPVMatch.Where(c => c.PPVId == ppvMatchNestedDto.PPVId && c.PPVMatchCount == ppvMatchNestedDto.PPVMatchCount).FirstOrDefault();
            if (ppvmatchcheck != null)
            {
                ppvmatchorder = _context.PPVMatch.Where(c => c.PPVId == ppvMatchNestedDto.PPVId && c.PPVMatchCount == ppvMatchNestedDto.PPVMatchCount)
                    .ToList().Max(m => m.PPVMatchOrder) + 1;
            };

            PPVMatch ppvmatch = new PPVMatch()
            {
                PPVMatchName = ppvMatchNestedDto.PPVMatchName,
                PPVMatchCount = ppvMatchNestedDto.PPVMatchCount,
                PPVMatchOrder = ppvmatchorder,
                PPVId = ppvMatchNestedDto.PPVId,
                ShowId = ppvMatchNestedDto.ShowId,
                MatchTitleId = ppvMatchNestedDto.MatchTitleId,
                MatchFormatId = ppvMatchNestedDto.MatchFormatId,
                isDone = false
            };

            _context.PPVMatch.AddAsync(ppvmatch);
            return ppvmatch;
        }

        public void AddPPVMatchChampionship(PPVMatchChampionshipDto ppvMatchChampionshipDto)
        {
            PPVMatchChampionship ppvMatchChampionship = new PPVMatchChampionship()
            {
                PPVMatchId = ppvMatchChampionshipDto.PPVMatchId,
                ChampionshipId = ppvMatchChampionshipDto.ChampionshipId
            };

            _context.PPVMatchChampionships.AddAsync(ppvMatchChampionship);
        }

        public PPVMatchTeam AddPPVMatchTeam(PPVMatchTeamDto ppvMatchTeamDto)
        {
            PPVMatchTeam ppvMatchTeam = new PPVMatchTeam()
            {
                PPVMatchId = ppvMatchTeamDto.PPVMatchId,
                isChampion = ppvMatchTeamDto.isChampion,
                isWinner = false
            };

            _context.PPVMatchTeams.AddAsync(ppvMatchTeam);
            return ppvMatchTeam;
        }

        public void AddPPVMatchParticipant(PPVMatchParticipantDto ppvMatchParticipantDto)
        {
            PPVMatchParticipant ppvMatchParticipant = new PPVMatchParticipant()
            {
                PPVMatchTeamId = ppvMatchParticipantDto.PPVMatchTeamId,
                SuperstarId = ppvMatchParticipantDto.SuperstarId
            };

            _context.PPVMatchParticipants.AddAsync(ppvMatchParticipant);
        }
        #endregion
    }
}
