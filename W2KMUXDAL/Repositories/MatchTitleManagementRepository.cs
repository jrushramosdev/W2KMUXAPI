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
    public class MatchTitleManagementRepository : IMatchTitleManagementRepository
    {
        private readonly W2KMUXContext _context;

        public MatchTitleManagementRepository(W2KMUXContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MatchTitleManagementDto>> GetMatchTitleManagementList()
        {
            List<MatchTitleManagementDto> matchTitleManagementDto = new List<MatchTitleManagementDto>();

            matchTitleManagementDto = await (from matchtitle in _context.MatchTitles
                                            orderby matchtitle.MatchTitleOrder ascending
                                            select new MatchTitleManagementDto
                                            {
                                                MatchTitleId = matchtitle.MatchTitleId,
                                                MatchTitleName = matchtitle.MatchTitleName,
                                                MatchTitleOrder = matchtitle.MatchTitleOrder
                                            }).ToListAsync();

            return matchTitleManagementDto;
        }

        public async Task<MatchTitleManagementDto> GetMatchTitleManagement(Guid id)
        {
            MatchTitleManagementDto matchTitleManagementDto = new MatchTitleManagementDto();

            matchTitleManagementDto = await (from matchtitle in _context.MatchTitles
                                            where matchtitle.MatchTitleId == id
                                            select new MatchTitleManagementDto
                                            {
                                                MatchTitleId = matchtitle.MatchTitleId,
                                                MatchTitleName = matchtitle.MatchTitleName,
                                                MatchTitleOrder = matchtitle.MatchTitleOrder
                                            }).FirstOrDefaultAsync();

            return matchTitleManagementDto;
        }

        public void AddMatchTitleManagement(MatchTitleManagementDto matchTitleManagementDto)
        {
            int matchTitleOrder = 1;
            var matchTitleManagement = _context.MatchTitles.FirstOrDefault();
            if (matchTitleManagement != null)
            {
                matchTitleOrder = _context.MatchTitles.ToList().Max(m => m.MatchTitleOrder) + 1;
            };

            MatchTitle matchTitle = new MatchTitle()
            {
                MatchTitleName = matchTitleManagementDto.MatchTitleName,
                MatchTitleOrder = matchTitleOrder
            };

            _context.MatchTitles.AddAsync(matchTitle);
        }

        public void UpdateMatchTitleManagement(MatchTitleManagementDto matchTitleManagementDto)
        {
            var matchTitleManagement = _context.MatchTitles.FirstOrDefault(m => m.MatchTitleId == matchTitleManagementDto.MatchTitleId);

            if (matchTitleManagement != null)
            {
                matchTitleManagement.MatchTitleName = matchTitleManagementDto.MatchTitleName;
                matchTitleManagement.MatchTitleOrder = matchTitleManagementDto.MatchTitleOrder;
            }
        }

        public void DeleteMatchTitleManagement(Guid id)
        {
            var matchTitleManagement = _context.MatchTitles.FirstOrDefault(m => m.MatchTitleId == id);

            if (matchTitleManagement != null)
            {
                _context.MatchTitles.Remove(matchTitleManagement);
            }
        }
    }
}
