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
    }
}
