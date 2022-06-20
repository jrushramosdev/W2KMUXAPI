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
    public class SuperstarRepository : ISuperstarRepository
    {
        private readonly W2KMUXContext _context;

        public SuperstarRepository(W2KMUXContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SuperstarDto>> GetSuperstarList()
        {
            List<SuperstarDto> superstarDto = new List<SuperstarDto>();

            superstarDto = await (from superstar in _context.Superstars
                                orderby superstar.SuperstarName ascending
                                select new SuperstarDto
                                {
                                    SuperstarId = superstar.SuperstarId,
                                    SuperstarName = superstar.SuperstarName,
                                    Gender = superstar.Gender,
                                    Role = superstar.Role,
                                    ShowId = superstar.ShowId,
                                    ShowName = superstar.Show.ShowName,
                                    TeamId = superstar.TeamId,
                                    TeamName = superstar.Team.TeamName,
                                    IsInjured = superstar.IsInjured,
                                    IsActive = superstar.IsActive
                                }).ToListAsync();

            foreach(var superstar in superstarDto)
            {
                var championSuperstar = _context.Championships.FirstOrDefault(m => m.SuperstarId == superstar.SuperstarId);

                if (championSuperstar != null)
                {
                    superstar.ChampionshipId = championSuperstar.ChampionshipId;
                    superstar.ChampionshipTypeId = championSuperstar.ChampionshipTypeId;
                    superstar.ChampionshipName = championSuperstar.ChampionshipName;
                }
            }

            return superstarDto;
        }

        public async Task<SuperstarDto> GetSuperstar(Guid id)
        {
            SuperstarDto superstarDto = new SuperstarDto();

            superstarDto = await (from superstar in _context.Superstars
                                where superstar.SuperstarId == id
                                select new SuperstarDto
                                {
                                    SuperstarId = superstar.SuperstarId,
                                    SuperstarName = superstar.SuperstarName,
                                    Gender = superstar.Gender,
                                    Role = superstar.Role,
                                    ShowId = superstar.ShowId,
                                    ShowName = superstar.Show.ShowName,
                                    TeamId = superstar.TeamId,
                                    TeamName = superstar.Team.TeamName,
                                    IsInjured = superstar.IsInjured,
                                    IsActive = superstar.IsActive
                                }).FirstOrDefaultAsync();

            var championSuperstar = _context.Championships.FirstOrDefault(m => m.SuperstarId == superstarDto.SuperstarId);

            if (championSuperstar != null)
            {
                superstarDto.ChampionshipId = championSuperstar.ChampionshipId;
                superstarDto.ChampionshipTypeId = championSuperstar.ChampionshipTypeId;
                superstarDto.ChampionshipName = championSuperstar.ChampionshipName;
            }

            return superstarDto;
        }

        public async Task<SuperstarDto> GetSuperstarByName(string superstarname)
        {
            SuperstarDto superstarDto = new SuperstarDto();

            superstarDto = await (from superstar in _context.Superstars
                                  where superstar.SuperstarName.Trim().ToLower() == superstarname.Trim().ToLower()
                                  select new SuperstarDto
                                  {
                                      SuperstarId = superstar.SuperstarId,
                                      SuperstarName = superstar.SuperstarName,
                                      Gender = superstar.Gender,
                                      Role = superstar.Role,
                                      ShowId = superstar.ShowId,
                                      ShowName = superstar.Show.ShowName,
                                      TeamId = superstar.TeamId,
                                      TeamName = superstar.Team.TeamName,
                                      IsInjured = superstar.IsInjured,
                                      IsActive = superstar.IsActive
                                  }).FirstOrDefaultAsync();

            return superstarDto;
        }

        public Superstar AddSuperstar(SuperstarDto superstarDto)
        {
            Superstar superstar = new Superstar()
            {
                SuperstarName = superstarDto.SuperstarName,
                Gender = superstarDto.Gender,
                Role = superstarDto.Role,
                ShowId = superstarDto.ShowId,
                TeamId = superstarDto.TeamId,
                IsInjured = superstarDto.IsInjured,
                IsActive = superstarDto.IsActive
            };

            _context.Superstars.AddAsync(superstar);
            return superstar;
        }

        public void UpdateSuperstar(SuperstarDto superstarDto)
        {
            var superstar = _context.Superstars.FirstOrDefault(m => m.SuperstarId == superstarDto.SuperstarId);

            if (superstar != null)
            {
                superstar.SuperstarName = superstarDto.SuperstarName;
                superstar.Gender = superstarDto.Gender;
                superstar.Role = superstarDto.Role;
                superstar.ShowId = superstarDto.ShowId;
                superstar.TeamId = superstarDto.TeamId;
                superstar.IsInjured = superstarDto.IsInjured;
                superstar.IsActive = superstarDto.IsActive;
            }
        }

        public void SoftDeleteSuperstar(Guid id)
        {
            var superstar = _context.Superstars.FirstOrDefault(m => m.SuperstarId == id);

            if (superstar != null)
            {
                superstar.IsActive = false;
            }
        }

        public void DeleteSuperstar(Guid id)
        {
            var superstar = _context.Superstars.FirstOrDefault(m => m.SuperstarId == id);

            if (superstar != null)
            {
                _context.Superstars.Remove(superstar);
            }
        }
    }
}
