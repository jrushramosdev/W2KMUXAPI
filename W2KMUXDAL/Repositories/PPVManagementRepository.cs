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
    public class PPVManagementRepository : IPPVManagementRepository
    {
        private readonly W2KMUXContext _context;

        public PPVManagementRepository(W2KMUXContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PPVManagementDto>> GetPPVManagementList()
        {
            List<PPVManagementDto> ppvManagementDto = new List<PPVManagementDto>();

            ppvManagementDto = await (from ppv in _context.Ppvs
                                       orderby ppv.PPVOrder ascending
                                       select new PPVManagementDto
                                       {
                                           PPVId = ppv.PPVId,
                                           PPVName = ppv.PPVName,
                                           PPVMonth = ppv.PPVMonth,
                                           ShowId = ppv.ShowId,
                                           ShowName = ppv.Show.ShowName,
                                           PPVOrder = ppv.PPVOrder,
                                           IsActive = ppv.IsActive
                                       }).ToListAsync();

            return ppvManagementDto;
        }

        public async Task<PPVManagementDto> GetPPVManagement(Guid id)
        {
            PPVManagementDto ppvManagementDto = new PPVManagementDto();

            ppvManagementDto = await (from ppv in _context.Ppvs
                                      where ppv.PPVId == id
                                      select new PPVManagementDto
                                      {
                                          PPVId = ppv.PPVId,
                                          PPVName = ppv.PPVName,
                                          PPVMonth = ppv.PPVMonth,
                                          ShowId = ppv.ShowId,
                                          ShowName = ppv.Show.ShowName,
                                          PPVOrder = ppv.PPVOrder,
                                          IsActive = ppv.IsActive
                                      }).FirstOrDefaultAsync();

            return ppvManagementDto;
        }

        public void AddPPVManagement(PPVManagementDto ppvManagementDto)
        {
            int ppvOrder = _context.Ppvs.ToList().Max(m => m.PPVOrder) + 1;

            Ppv ppvManagement = new Ppv()
            {
                PPVName = ppvManagementDto.PPVName,
                PPVMonth = ppvManagementDto.PPVMonth,
                ShowId = ppvManagementDto.ShowId,
                PPVOrder = ppvOrder,
                IsActive = true
            };

            _context.Ppvs.AddAsync(ppvManagement);
        }

        public void UpdatePPVManagement(PPVManagementDto ppvManagementDto)
        {
            var ppvManagement = _context.Ppvs.FirstOrDefault(m => m.PPVId == ppvManagementDto.PPVId);

            if (ppvManagement != null)
            {
                ppvManagement.PPVName = ppvManagementDto.PPVName;
                ppvManagement.PPVMonth = ppvManagementDto.PPVMonth;
                ppvManagement.ShowId = ppvManagementDto.ShowId;
                ppvManagement.PPVOrder = ppvManagementDto.PPVOrder;
                ppvManagement.IsActive = ppvManagementDto.IsActive;
            }
        }

        public void SoftDeletePPVManagement(Guid id)
        {
            var ppvManagement = _context.Ppvs.FirstOrDefault(m => m.PPVId == id);

            if (ppvManagement != null)
            {
                ppvManagement.IsActive = false;
            }
        }

        public void DeletePPVManagement(Guid id)
        {
            var ppvManagement = _context.Ppvs.FirstOrDefault(m => m.PPVId == id);

            if (ppvManagement != null)
            {
                _context.Ppvs.Remove(ppvManagement);
            }
        }
    }
}
