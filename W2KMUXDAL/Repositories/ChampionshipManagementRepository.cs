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
    public class ChampionshipManagementRepository : IChampionshipManagementRepository
    {
        private readonly W2KMUXContext _context;

        public ChampionshipManagementRepository(W2KMUXContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ChampionshipManagementDto>> GetChampionshipManagementList()
        {
            List<ChampionshipManagementDto> championshipManagementDto = new List<ChampionshipManagementDto>();

            championshipManagementDto = await (from championship in _context.Championships
                                               select new ChampionshipManagementDto
                                               {
                                                   ChampionshipId = championship.ChampionshipId,
                                                   ChampionshipName = championship.ChampionshipName,
                                                   ChampionshipTypeId = championship.ChampionshipTypeId,
                                                   ChampionshipTypeName = championship.ChampionshipType.ChampionshipTypeName,
                                                   SuperstarId = championship.SuperstarId,
                                                   SuperstarName = championship.Superstar.SuperstarName,
                                                   ShowId = championship.ShowId,
                                                   ShowName = championship.Show.ShowName,
                                                   ChampionshipOrder = championship.ChampionshipOrder,
                                                   IsActive = championship.IsActive
                                               }).ToListAsync();

            return championshipManagementDto;
        }

        public async Task<ChampionshipManagementDto> GetChampionshipManagement(Guid id)
        {
            ChampionshipManagementDto championshipManagementDto = new ChampionshipManagementDto();

            championshipManagementDto = await (from championship in _context.Championships
                                                where championship.ChampionshipId == id
                                                select new ChampionshipManagementDto
                                                {
                                                    ChampionshipId = championship.ChampionshipId,
                                                    ChampionshipName = championship.ChampionshipName,
                                                    ChampionshipTypeId = championship.ChampionshipTypeId,
                                                    ChampionshipTypeName = championship.ChampionshipType.ChampionshipTypeName,
                                                    SuperstarId = championship.SuperstarId,
                                                    SuperstarName = championship.Superstar.SuperstarName,
                                                    ShowId = championship.ShowId,
                                                    ShowName = championship.Show.ShowName,
                                                    ChampionshipOrder = championship.ChampionshipOrder,
                                                    IsActive = championship.IsActive
                                                }).FirstOrDefaultAsync();

            return championshipManagementDto;
        }

        public async Task<ChampionshipManagementDto> GetChampionshipManagementBySuperstarId(Guid superstarid)
        {
            ChampionshipManagementDto championshipManagementDto = new ChampionshipManagementDto();

            championshipManagementDto = await (from championship in _context.Championships
                                               where championship.SuperstarId == superstarid
                                               select new ChampionshipManagementDto
                                               {
                                                   ChampionshipId = championship.ChampionshipId,
                                                   ChampionshipName = championship.ChampionshipName,
                                                   ChampionshipTypeId = championship.ChampionshipTypeId,
                                                   ChampionshipTypeName = championship.ChampionshipType.ChampionshipTypeName,
                                                   SuperstarId = championship.SuperstarId,
                                                   SuperstarName = championship.Superstar.SuperstarName,
                                                   ShowId = championship.ShowId,
                                                   ShowName = championship.Show.ShowName,
                                                   ChampionshipOrder = championship.ChampionshipOrder,
                                                   IsActive = championship.IsActive
                                               }).FirstOrDefaultAsync();

            return championshipManagementDto;
        }

        public void AddChampionshipManagement(ChampionshipManagementDto championshipManagementDto)
        {
            Championship championship = new Championship()
            {
                ChampionshipName = championshipManagementDto.ChampionshipName,
                ChampionshipTypeId = championshipManagementDto.ChampionshipTypeId,
                SuperstarId = championshipManagementDto.SuperstarId,
                ShowId = championshipManagementDto.ShowId,
                ChampionshipOrder = championshipManagementDto.ChampionshipOrder,
                IsActive = true
            };

            _context.Championships.AddAsync(championship);
        }

        public void UpdateChampionshipManagement(ChampionshipManagementDto championshipManagementDto)
        {
            var championshipManagement = _context.Championships.FirstOrDefault(m => m.ChampionshipId == championshipManagementDto.ChampionshipId);

            if (championshipManagement != null)
            {
                championshipManagement.ChampionshipName = championshipManagementDto.ChampionshipName;
                championshipManagement.ChampionshipTypeId = championshipManagementDto.ChampionshipTypeId;
                championshipManagement.SuperstarId = championshipManagementDto.SuperstarId;
                championshipManagement.ShowId = championshipManagementDto.ShowId;
                championshipManagement.ChampionshipOrder = championshipManagementDto.ChampionshipOrder;
                championshipManagement.IsActive = championshipManagementDto.IsActive;
            }
        }

        public void SoftDeleteChampionshipManagement(Guid id)
        {
            var championshipManagement = _context.Championships.FirstOrDefault(m => m.ChampionshipId == id);

            if (championshipManagement != null)
            {
                championshipManagement.IsActive = false;
            }
        }

        public void DeleteChampionshipManagement(Guid id)
        {
            var championshipManagement = _context.Championships.FirstOrDefault(m => m.ChampionshipId == id);

            if (championshipManagement != null)
            {
                _context.Championships.Remove(championshipManagement);
            }
        }
    }
}
