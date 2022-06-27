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

        public async Task<IEnumerable<PPVMatchNestedDto>> GetPPVMatchNestedList(Guid ppvid, int ppvcount)
        {
            List<PPVMatchNestedDto> ppvMatchNestedDto = new List<PPVMatchNestedDto>();

            var ppvMatchList = await unitOfWork.PPVMatchRepository.GetPPVMatchList(ppvid, ppvcount);

            if (ppvMatchList.Count() > 0)
            {
                foreach (var ppvMatch in ppvMatchList)
                {

                }
            }
            else
            {
                var ppvManagement = await unitOfWork.PPVManagementRepository.GetPPVManagement(ppvid);
                PPVMatchNestedDto tempPPVMatchNestedDto = new PPVMatchNestedDto()
                {
                    PPVMatchCount = ppvcount,
                    PPVId = ppvManagement.PPVId,
                    PPVName = ppvManagement.PPVName,
                    IsDone = false
                };

                ppvMatchNestedDto.Add(tempPPVMatchNestedDto);
            }

            return ppvMatchNestedDto;
        }

        public async Task<PPVMatchLatestDto> GetPPVMatchLatest()
        {
            var result = await unitOfWork.PPVMatchRepository.GetPPVMatchLatest();
            if (result == null)
            {
                result = await unitOfWork.PPVMatchRepository.GetPPVMatchDefault();
            }
            return result;
        }
    }
}
