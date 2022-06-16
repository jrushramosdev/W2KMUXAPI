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
    public class TeamHistoryRepository : ITeamHistoryRepository
    {
        private readonly W2KMUXContext _context;

        public TeamHistoryRepository(W2KMUXContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TeamHistoryDto>> GetTeamHistoryList()
        {
            List<TeamHistoryDto> teamHistoryDto = new List<TeamHistoryDto>();

            teamHistoryDto = await (from teamHistory in _context.TeamHistory
                                    select new TeamHistoryDto
                                    {
                                        TeamHistoryId = teamHistory.TeamHistoryId,
                                        TeamId = teamHistory.TeamId,
                                        TeamName = teamHistory.Team.TeamName,
                                        SuperstarId = teamHistory.SuperstarId,
                                        SuperstarName = teamHistory.Superstar.SuperstarName,
                                        IsActive = teamHistory.IsActive
                                    }).ToListAsync();

            return teamHistoryDto;
        }

        public async Task<IEnumerable<TeamHistoryDto>> GetTeamHistoryListBySuperstarId(Guid superstarid)
        {
            List<TeamHistoryDto> teamHistoryDto = new List<TeamHistoryDto>();

            teamHistoryDto = await (from teamHistory in _context.TeamHistory
                                    where teamHistory.SuperstarId == superstarid
                                    select new TeamHistoryDto
                                    {
                                        TeamHistoryId = teamHistory.TeamHistoryId,
                                        TeamId = teamHistory.TeamId,
                                        TeamName = teamHistory.Team.TeamName,
                                        SuperstarId = teamHistory.SuperstarId,
                                        SuperstarName = teamHistory.Superstar.SuperstarName,
                                        IsActive = teamHistory.IsActive
                                    }).ToListAsync();

            return teamHistoryDto;
        }

        public async Task<IEnumerable<TeamHistoryDto>> GetTeamHistoryListByTeamId(Guid teamid)
        {
            List<TeamHistoryDto> teamHistoryDto = new List<TeamHistoryDto>();

            teamHistoryDto = await (from teamHistory in _context.TeamHistory
                                    where teamHistory.TeamId == teamid
                                    select new TeamHistoryDto
                                    {
                                        TeamHistoryId = teamHistory.TeamHistoryId,
                                        TeamId = teamHistory.TeamId,
                                        TeamName = teamHistory.Team.TeamName,
                                        SuperstarId = teamHistory.SuperstarId,
                                        SuperstarName = teamHistory.Superstar.SuperstarName,
                                        IsActive = teamHistory.IsActive
                                    }).ToListAsync();

            return teamHistoryDto;
        }

        public async Task<TeamHistoryDto> GetTeamHistory(Guid id)
        {
            TeamHistoryDto teamHistoryDto = new TeamHistoryDto();

            teamHistoryDto = await (from teamHistory in _context.TeamHistory
                                    where teamHistory.TeamHistoryId == id
                                    select new TeamHistoryDto
                                    {
                                        TeamHistoryId = teamHistory.TeamHistoryId,
                                        TeamId = teamHistory.TeamId,
                                        TeamName = teamHistory.Team.TeamName,
                                        SuperstarId = teamHistory.SuperstarId,
                                        SuperstarName = teamHistory.Superstar.SuperstarName,
                                        IsActive = teamHistory.IsActive
                                    }).FirstOrDefaultAsync();

            return teamHistoryDto;
        }

        public void AddTeamHistory(TeamHistoryDto teamHistoryDto)
        {
            TeamHistory teamHistory = new TeamHistory()
            {
                TeamId = teamHistoryDto.TeamId,
                SuperstarId = teamHistoryDto.SuperstarId,
                IsActive = teamHistoryDto.IsActive
            };

            _context.TeamHistory.AddAsync(teamHistory);
        }

        public void UpdateTeamHistory(TeamHistoryDto teamHistoryDto)
        {
            var teamHistory = _context.TeamHistory.FirstOrDefault(m => m.TeamHistoryId == teamHistoryDto.TeamHistoryId); //Lamda Expression

            if (teamHistory != null)
            {
                teamHistory.TeamId = teamHistoryDto.TeamId;
                teamHistory.SuperstarId = teamHistoryDto.SuperstarId;
                teamHistory.IsActive = teamHistoryDto.IsActive;
            }
        }

        public void UpdateTeamHistoryStatusList(Guid superstarid, bool isactive)
        {
            var teamHistory = _context.TeamHistory.Where(m => m.SuperstarId == superstarid).ToList();

            teamHistory.ForEach(m => m.IsActive = isactive);
        }

        public void SoftDeleteTeamHistory(Guid id)
        {
            var teamHistory = _context.TeamHistory.FirstOrDefault(m => m.TeamHistoryId == id);

            if (teamHistory != null)
            {
                teamHistory.IsActive = false;
            }
        }

        public void DeleteTeamHistory(Guid id)
        {
            var teamHistory = _context.TeamHistory.FirstOrDefault(m => m.TeamHistoryId == id);

            if (teamHistory != null)
            {
                _context.TeamHistory.Remove(teamHistory);
            }
        }
    }
}
