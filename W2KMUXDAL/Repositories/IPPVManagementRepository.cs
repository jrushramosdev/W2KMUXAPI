using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Models;

namespace W2KMUXDAL.Repositories
{
    public interface IPPVManagementRepository
    {
        Task<IEnumerable<PPVManagementDto>> GetPPVManagementList();
        Task<PPVManagementDto> GetPPVManagement(Guid id);
        void AddPPVManagement(PPVManagementDto ppvManagementDto);
        void UpdatePPVManagement(PPVManagementDto ppvManagementDto);
        void SoftDeletePPVManagement(Guid id);
        void DeletePPVManagement(Guid id);
    }
}
