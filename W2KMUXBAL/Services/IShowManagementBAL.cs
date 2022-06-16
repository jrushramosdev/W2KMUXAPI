using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Models;

namespace W2KMUXBAL.Services
{
    public interface IShowManagementBAL
    {
        Task<IEnumerable<ShowManagementDto>> GetShowManagementList();
        Task<ShowManagementDto> GetShowManagement(Guid id);
        Task<bool> AddShowManagement(ShowManagementDto showManagementDto);
        Task<bool> UpdateShowManagement(ShowManagementDto showManagementDto);
        Task<bool> SoftDeleteShowManagement(Guid id);
        Task<bool> DeleteShowManagement(Guid id);
    }
}
