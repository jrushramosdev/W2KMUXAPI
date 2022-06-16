using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Data.Models;
using W2KMUXDAL.Models;

namespace W2KMUXDAL.Repositories
{
    public interface ISuperstarRepository
    {
        Task<IEnumerable<SuperstarDto>> GetSuperstarList();
        Task<SuperstarDto> GetSuperstar(Guid id);
        Task<SuperstarDto> GetSuperstarByName(string superstarname);
        Superstar AddSuperstar(SuperstarDto ppvManagementDto);
        void UpdateSuperstar(SuperstarDto ppvManagementDto);
        void SoftDeleteSuperstar(Guid id);
        void DeleteSuperstar(Guid id);
    }
}
