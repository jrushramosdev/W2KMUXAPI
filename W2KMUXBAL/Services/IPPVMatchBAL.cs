using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Models;

namespace W2KMUXBAL.Services
{
    public interface IPPVMatchBAL
    {
        Task<PPVMatchLatestDto> GetPPVMatchLatest();
    }
}
