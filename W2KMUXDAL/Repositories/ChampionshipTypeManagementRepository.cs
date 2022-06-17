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
    public class ChampionshipTypeManagementRepository : IChampionshipTypeManagementRepository
    {
        private readonly W2KMUXContext _context;

        public ChampionshipTypeManagementRepository(W2KMUXContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ChampionshipTypeManagementDto>> GetChampionshipTypeManagementList()
        {
            List<ChampionshipTypeManagementDto> championshipTypeManagementDto = new List<ChampionshipTypeManagementDto>();

            championshipTypeManagementDto = await (from championshiptype in _context.ChampionshipTypes
                                                   orderby championshiptype.ChampionshipTypeName
                                                   select new ChampionshipTypeManagementDto
                                                   {
                                                       ChampionshipTypeId = championshiptype.ChampionshipTypeId,
                                                       ChampionshipTypeName = championshiptype.ChampionshipTypeName,
                                                       IsActive = championshiptype.IsActive
                                                   }).ToListAsync();

            return championshipTypeManagementDto;
        }

        public async Task<ChampionshipTypeManagementDto> GetChampionshipTypeManagement(Guid id)
        {
            ChampionshipTypeManagementDto championshipTypeManagementDto = new ChampionshipTypeManagementDto();

            championshipTypeManagementDto = await (from championshiptype in _context.ChampionshipTypes
                                                  where championshiptype.ChampionshipTypeId == id
                                                  select new ChampionshipTypeManagementDto
                                                  {
                                                      ChampionshipTypeId = championshiptype.ChampionshipTypeId,
                                                      ChampionshipTypeName = championshiptype.ChampionshipTypeName,
                                                      IsActive = championshiptype.IsActive
                                                  }).FirstOrDefaultAsync();

            return championshipTypeManagementDto;
        }

        public void AddChampionshipTypeManagement(ChampionshipTypeManagementDto championshipTypeManagementDto)
        {
            ChampionshipType championshipType = new ChampionshipType()
            {
                ChampionshipTypeName = championshipTypeManagementDto.ChampionshipTypeName,
                IsActive = true
            };

            _context.ChampionshipTypes.AddAsync(championshipType);
        }

        public void UpdateChampionshipTypeManagement(ChampionshipTypeManagementDto championshipTypeManagementDto)
        {
            var championshipTypeManagement = _context.ChampionshipTypes.FirstOrDefault(m => m.ChampionshipTypeId == championshipTypeManagementDto.ChampionshipTypeId);

            if (championshipTypeManagement != null)
            {
                championshipTypeManagement.ChampionshipTypeName = championshipTypeManagementDto.ChampionshipTypeName;
                championshipTypeManagement.IsActive = championshipTypeManagementDto.IsActive;
            }
        }

        public void SoftDeleteChampionshipTypeManagement(Guid id)
        {
            var championshipTypeManagement = _context.ChampionshipTypes.FirstOrDefault(m => m.ChampionshipTypeId == id);

            if (championshipTypeManagement != null)
            {
                championshipTypeManagement.IsActive = false;
            }
        }

        public void DeleteChampionshipTypeManagement(Guid id)
        {
            var championshipTypeManagement = _context.ChampionshipTypes.FirstOrDefault(m => m.ChampionshipTypeId == id);

            if (championshipTypeManagement != null)
            {
                _context.ChampionshipTypes.Remove(championshipTypeManagement);
            }
        }
    }
}
