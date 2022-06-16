using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Models;

namespace W2KMUXDAL.Repositories
{
    public interface IShowManagementRepository
    {
        Task<IEnumerable<ShowManagementDto>> GetShowManagementList();
        Task<ShowManagementDto> GetShowManagement(Guid id);
        void AddShowManagement(ShowManagementDto showManagementDto);
        void UpdateShowManagement(ShowManagementDto showManagementDto);
        void SoftDeleteShowManagement(Guid id);
        void DeleteShowManagement(Guid id);
    }
}
