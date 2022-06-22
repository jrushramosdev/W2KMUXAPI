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
    public class MatchTypeManagementRepository : IMatchTypeManagementRepository
    {
        private readonly W2KMUXContext _context;

        public MatchTypeManagementRepository(W2KMUXContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MatchTypeManagementDto>> GetMatchTypeManagementList()
        {
            List<MatchTypeManagementDto> matchTypeManagementDto = new List<MatchTypeManagementDto>();

            matchTypeManagementDto = await (from matchtype in _context.MatchTypes
                                    orderby matchtype.MatchTypeOrder ascending
                                    select new MatchTypeManagementDto
                                    {
                                        MatchTypeId = matchtype.MatchTypeId,
                                        MatchTypeName = matchtype.MatchTypeName,
                                        MatchTypeOrder = matchtype.MatchTypeOrder
                                    }).ToListAsync();

            return matchTypeManagementDto;
        }

        public async Task<MatchTypeManagementDto> GetMatchTypeManagement(Guid id)
        {
            MatchTypeManagementDto matchTypeManagementDto = new MatchTypeManagementDto();

            matchTypeManagementDto = await (from matchtype in _context.MatchTypes
                                            where matchtype.MatchTypeId == id
                                            select new MatchTypeManagementDto
                                            {
                                                MatchTypeId = matchtype.MatchTypeId,
                                                MatchTypeName = matchtype.MatchTypeName,
                                                MatchTypeOrder = matchtype.MatchTypeOrder
                                            }).FirstOrDefaultAsync();

            return matchTypeManagementDto;
        }

        public void AddMatchTypeManagement(MatchTypeManagementDto matchTypeManagementDto)
        {
            int matchTypeOrder = 1;
            var matchTypeManagement = _context.MatchTypes.FirstOrDefault();
            if (matchTypeManagement != null)
            {
                matchTypeOrder = _context.MatchTypes.ToList().Max(m => m.MatchTypeOrder) + 1;
            };

            MatchType matchType = new MatchType()
            {
                MatchTypeName = matchTypeManagementDto.MatchTypeName,
                MatchTypeOrder = matchTypeOrder
            };

            _context.MatchTypes.AddAsync(matchType);
        }

        public void UpdateMatchTypeManagement(MatchTypeManagementDto matchTypeManagementDto)
        {
            var matchTypeManagement = _context.MatchTypes.FirstOrDefault(m => m.MatchTypeId == matchTypeManagementDto.MatchTypeId);

            if (matchTypeManagement != null)
            {
                matchTypeManagement.MatchTypeName = matchTypeManagementDto.MatchTypeName;
                matchTypeManagement.MatchTypeOrder = matchTypeManagementDto.MatchTypeOrder;
            }
        }

        public void DeleteMatchTypeManagement(Guid id)
        {
            var matchTypeManagement = _context.MatchTypes.FirstOrDefault(m => m.MatchTypeId == id);

            if (matchTypeManagement != null)
            {
                _context.MatchTypes.Remove(matchTypeManagement);
            }
        }
    }
}
