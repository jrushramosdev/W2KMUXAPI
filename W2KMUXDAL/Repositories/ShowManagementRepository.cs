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
    public class ShowManagementRepository : IShowManagementRepository
    {
        private readonly W2KMUXContext _context;

        public ShowManagementRepository(W2KMUXContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ShowManagementDto>> GetShowManagementList()
        {
            List<ShowManagementDto> showManagementDto = new List<ShowManagementDto>();

            //var showM = await _context.Shows.Where(show => show.IsActive == true).ToListAsync();

            showManagementDto = await (from show in _context.Shows
                                    orderby show.ShowOrder ascending
                                    select new ShowManagementDto
                                    {
                                        ShowId = show.ShowId,
                                        ShowName = show.ShowName,
                                        ShowOrder = show.ShowOrder,
                                        IsActive = show.IsActive
                                    }).ToListAsync();

            return showManagementDto;
        }

        public async Task<ShowManagementDto> GetShowManagement(Guid id)
        {
            ShowManagementDto showManagementDto = new ShowManagementDto();

            showManagementDto = await (from show in _context.Shows
                                       where show.ShowId == id
                                       select new ShowManagementDto
                                       {
                                           ShowId = show.ShowId,
                                           ShowName = show.ShowName,
                                           ShowOrder = show.ShowOrder,
                                           IsActive = show.IsActive
                                       }).FirstOrDefaultAsync();

            return showManagementDto;
        }

        public void AddShowManagement(ShowManagementDto showManagementDto)
        {
            int showOrder = _context.Shows.ToList().Max(m => m.ShowOrder) + 1;

            Show showManagement = new Show()
            {
                ShowName = showManagementDto.ShowName,
                ShowOrder = showOrder,
                IsActive = true
            };

            _context.Shows.AddAsync(showManagement);
        }

        public void UpdateShowManagement(ShowManagementDto showManagementDto)
        {
            var showManagement = _context.Shows.FirstOrDefault(m => m.ShowId == showManagementDto.ShowId);

            if (showManagement != null)
            {
                showManagement.ShowName = showManagementDto.ShowName;
                showManagement.ShowOrder = showManagementDto.ShowOrder;
                showManagement.IsActive = showManagementDto.IsActive;
            }
        }

        public void SoftDeleteShowManagement(Guid id)
        {
            var showManagement = _context.Shows.FirstOrDefault(m => m.ShowId == id);

            if (showManagement != null)
            {
                showManagement.IsActive = false;
            } 
        }

        public void DeleteShowManagement(Guid id)
        {
            var showManagement = _context.Shows.FirstOrDefault(m => m.ShowId == id);

            if (showManagement != null)
            {
                _context.Shows.Remove(showManagement);
            }     
        }
    }
}
