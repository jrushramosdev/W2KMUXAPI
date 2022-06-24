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
    public class MatchFormatManagementRepository : IMatchFormatManagementRepository
    {
        private readonly W2KMUXContext _context;

        public MatchFormatManagementRepository(W2KMUXContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<MatchFormatManagementDto>> GetMatchFormatManagementList()
        {
            List<MatchFormatManagementDto> matchFormatManagementDto = new List<MatchFormatManagementDto>();

            matchFormatManagementDto = await (from matchformat in _context.MatchFormats
                                            orderby matchformat.MatchFormatOrder ascending
                                            select new MatchFormatManagementDto
                                            {
                                                MatchFormatId = matchformat.MatchFormatId,
                                                MatchFormatName = matchformat.MatchFormatName,
                                                MatchTypeId = matchformat.MatchTypeId,
                                                MatchTypeName = matchformat.MatchType.MatchTypeName,
                                                TeamsCount = matchformat.TeamsCount,
                                                HandicapCount = matchformat.HandicapCount,
                                                ParticipantCount = matchformat.ParticipantCount,
                                                MatchFormatOrder = matchformat.MatchFormatOrder
                                            }).ToListAsync();

            return matchFormatManagementDto;
        }

        public async Task<MatchFormatManagementDto> GetMatchFormatManagement(Guid id)
        {
            MatchFormatManagementDto matchFormatManagementDto = new MatchFormatManagementDto();

            matchFormatManagementDto = await (from matchformat in _context.MatchFormats
                                            where matchformat.MatchFormatId == id
                                            select new MatchFormatManagementDto
                                            {
                                                MatchFormatId = matchformat.MatchFormatId,
                                                MatchFormatName = matchformat.MatchFormatName,
                                                MatchTypeId = matchformat.MatchTypeId,
                                                MatchTypeName = matchformat.MatchType.MatchTypeName,
                                                TeamsCount = matchformat.TeamsCount,
                                                HandicapCount = matchformat.HandicapCount,
                                                ParticipantCount = matchformat.ParticipantCount,
                                                MatchFormatOrder = matchformat.MatchFormatOrder
                                            }).FirstOrDefaultAsync();

            return matchFormatManagementDto;
        }

        public void AddMatchFormatManagement(MatchFormatManagementDto matchFormatManagementDto)
        {
            int matchFormatOrder = 1;
            var matchFormatManagement = _context.MatchFormats.FirstOrDefault();
            if (matchFormatManagement != null)
            {
                matchFormatOrder = _context.MatchFormats.ToList().Max(m => m.MatchFormatOrder) + 1;
            };

            MatchFormat matchFormat = new MatchFormat()
            {
                MatchFormatName = matchFormatManagementDto.MatchFormatName,
                MatchTypeId = matchFormatManagementDto.MatchTypeId,
                TeamsCount = matchFormatManagementDto.TeamsCount,
                HandicapCount = matchFormatManagementDto.HandicapCount,
                ParticipantCount = matchFormatManagementDto.ParticipantCount,
                MatchFormatOrder = matchFormatOrder
            };

            _context.MatchFormats.AddAsync(matchFormat);
        }

        public void UpdateMatchFormatManagement(MatchFormatManagementDto matchFormatManagementDto)
        {
            var matchFormatManagement = _context.MatchFormats.FirstOrDefault(m => m.MatchFormatId == matchFormatManagementDto.MatchFormatId);

            if (matchFormatManagement != null)
            {
                matchFormatManagement.MatchFormatName = matchFormatManagementDto.MatchFormatName;
                matchFormatManagement.MatchTypeId = matchFormatManagementDto.MatchTypeId;
                matchFormatManagement.TeamsCount = matchFormatManagementDto.TeamsCount;
                matchFormatManagement.HandicapCount = matchFormatManagementDto.HandicapCount;
                matchFormatManagement.ParticipantCount = matchFormatManagementDto.ParticipantCount;
                matchFormatManagement.MatchFormatOrder = matchFormatManagementDto.MatchFormatOrder;
            }
        }

        public void DeleteMatchFormatManagement(Guid id)
        {
            var matchFormatManagement = _context.MatchFormats.FirstOrDefault(m => m.MatchFormatId == id);

            if (matchFormatManagement != null)
            {
                _context.MatchFormats.Remove(matchFormatManagement);
            }
        }
    }
}
