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
    public class TeamManagementRepository : ITeamManagementRepository
    {
        private readonly W2KMUXContext _context;

        public TeamManagementRepository(W2KMUXContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TeamManagementDto>> GetTeamManagementList()
        {
            List<TeamManagementDto> teamManagementDto = new List<TeamManagementDto>();

            teamManagementDto = await (from team in _context.Teams
                                      orderby team.TeamName ascending
                                      select new TeamManagementDto
                                      {
                                          TeamId = team.TeamId,
                                          TeamName = team.TeamName,
                                          IsActive = team.IsActive
                                      }).ToListAsync();

            return teamManagementDto;
        }

        public async Task<TeamManagementDto> GetTeamManagement(Guid id)
        {
            TeamManagementDto teamManagementDto = new TeamManagementDto();

            teamManagementDto = await (from team in _context.Teams
                                      where team.TeamId == id
                                      select new TeamManagementDto
                                      {
                                          TeamId = team.TeamId,
                                          TeamName = team.TeamName,
                                          IsActive = team.IsActive
                                      }).FirstOrDefaultAsync();

            return teamManagementDto;
        }

        public void AddTeamManagement(TeamManagementDto teamManagementDto)
        {
            Team teamManagement = new Team()
            {
                TeamName = teamManagementDto.TeamName,
                IsActive = true
            };

            _context.Teams.AddAsync(teamManagement);
        }

        public void UpdateTeamManagement(TeamManagementDto teamManagementDto)
        {
            var teamManagement = _context.Teams.FirstOrDefault(m => m.TeamId == teamManagementDto.TeamId);

            if (teamManagement != null)
            {
                teamManagement.TeamName = teamManagementDto.TeamName;
                teamManagement.IsActive = teamManagementDto.IsActive;
            }
        }

        public void SoftDeleteTeamManagement(Guid id)
        {
            var teamManagement = _context.Teams.FirstOrDefault(m => m.TeamId == id);

            if (teamManagement != null)
            {
                teamManagement.IsActive = false;
            }
        }

        public void DeleteTeamManagement(Guid id)
        {
            var teamManagement = _context.Teams.FirstOrDefault(m => m.TeamId == id);

            if (teamManagement != null)
            {
                _context.Teams.Remove(teamManagement);
            }
        }
    }
}
