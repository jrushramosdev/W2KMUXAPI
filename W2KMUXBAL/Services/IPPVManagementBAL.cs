using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Models;

namespace W2KMUXBAL.Services
{
    public interface IPPVManagementBAL
    {
        Task<IEnumerable<PPVManagementDto>> GetPPVManagementList();
        Task<PPVManagementDto> GetPPVManagement(Guid id);
        Task<bool> AddPPVManagement(PPVManagementDto ppvManagementDto);
        Task<bool> UpdatePPVManagement(PPVManagementDto ppvManagementDto);
        Task<bool> SoftDeletePPVManagement(Guid id);
        Task<bool> DeletePPVManagement(Guid id);
    }
}
