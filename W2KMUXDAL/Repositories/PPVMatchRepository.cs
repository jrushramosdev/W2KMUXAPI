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
                                        IsDone = ppvmatch.isDone
                                     }).FirstOrDefaultAsync();

            return ppvMatchLatestDto;
        }
    }
}
