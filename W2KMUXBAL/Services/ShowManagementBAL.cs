using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Repositories;
using W2KMUXDAL.Data;
using W2KMUXDAL.Models;

namespace W2KMUXBAL.Services
{
    public class ShowManagementBAL : IShowManagementBAL
    {
        private readonly IUnitOfWork unitOfWork;

        public ShowManagementBAL(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ShowManagementDto>> GetShowManagementList()
        {
            var result = await unitOfWork.ShowManagementRepository.GetShowManagementList();
            return result;
        }

        public async Task<ShowManagementDto> GetShowManagement(Guid id)
        {
            var result = await unitOfWork.ShowManagementRepository.GetShowManagement(id);
            return result;
        }

        public async Task<bool> AddShowManagement(ShowManagementDto showManagementDto)
        {
            unitOfWork.ShowManagementRepository.AddShowManagement(showManagementDto);
            return await unitOfWork.SaveAsync();
        }

        public async Task<bool> UpdateShowManagement(ShowManagementDto showManagementDto)
        {
            unitOfWork.ShowManagementRepository.UpdateShowManagement(showManagementDto);
            return await unitOfWork.SaveAsync();
        }

        public async Task<bool> SoftDeleteShowManagement(Guid id)
        {
            unitOfWork.ShowManagementRepository.SoftDeleteShowManagement(id);
            return await unitOfWork.SaveAsync();
        }

        public async Task<bool> DeleteShowManagement(Guid id)
        {
            unitOfWork.ShowManagementRepository.DeleteShowManagement(id);
            return await unitOfWork.SaveAsync();
        }
    }
}
