using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Data;
using W2KMUXDAL.Models;

namespace W2KMUXBAL.Services
{
    public class PPVManagementBAL : IPPVManagementBAL
    {
        private readonly IUnitOfWork unitOfWork;

        public PPVManagementBAL(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PPVManagementDto>> GetPPVManagementList()
        {
            var result = await unitOfWork.PPVManagementRepository.GetPPVManagementList();
            return result;
        }

        public async Task<PPVManagementDto> GetPPVManagement(Guid id)
        {
            var result = await unitOfWork.PPVManagementRepository.GetPPVManagement(id);
            return result;
        }

        public async Task<bool> AddPPVManagement(PPVManagementDto ppvManagementDto)
        {
            unitOfWork.PPVManagementRepository.AddPPVManagement(ppvManagementDto);
            return await unitOfWork.SaveAsync();
        }

        public async Task<bool> UpdatePPVManagement(PPVManagementDto ppvManagementDto)
        {
            unitOfWork.PPVManagementRepository.UpdatePPVManagement(ppvManagementDto);
            return await unitOfWork.SaveAsync();
        }

        public async Task<bool> SoftDeletePPVManagement(Guid id)
        {
            unitOfWork.PPVManagementRepository.SoftDeletePPVManagement(id);
            return await unitOfWork.SaveAsync();
        }

        public async Task<bool> DeletePPVManagement(Guid id)
        {
            unitOfWork.PPVManagementRepository.DeletePPVManagement(id);
            return await unitOfWork.SaveAsync();
        }
    }
}
