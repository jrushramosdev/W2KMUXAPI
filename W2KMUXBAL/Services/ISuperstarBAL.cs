using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Models;

namespace W2KMUXBAL.Services
{
    public interface ISuperstarBAL
    {
        Task<IEnumerable<SuperstarDto>> GetSuperstarList();
        Task<SuperstarDto> GetSuperstar(Guid id);
        Task<(bool, string)> AddSuperstar(SuperstarDto superstarDto);
        Task<bool> UpdateSuperstar(SuperstarDto superstarDto);
        Task<bool> SoftDeleteSuperstar(Guid id);
        Task<bool> DeleteSuperstar(Guid id);
    }
}
