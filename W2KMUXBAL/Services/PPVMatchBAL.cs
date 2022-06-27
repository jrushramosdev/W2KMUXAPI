using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Data;
using W2KMUXDAL.Models;

namespace W2KMUXBAL.Services
{
    public class PPVMatchBAL : IPPVMatchBAL
    {
        private readonly IUnitOfWork unitOfWork;

        public PPVMatchBAL(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<PPVMatchLatestDto> GetPPVMatchLatest()
        {
            var result = await unitOfWork.PPVMatchRepository.GetPPVMatchLatest();
            return result;
        }
    }
}
