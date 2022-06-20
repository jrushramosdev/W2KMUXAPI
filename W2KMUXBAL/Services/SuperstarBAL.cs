using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Repositories;
using W2KMUXDAL.Data;
using W2KMUXDAL.Data.Models;
using W2KMUXDAL.Models;

namespace W2KMUXBAL.Services
{
    public class SuperstarBAL : ISuperstarBAL
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ITeamHistoryBAL _teamHistoryBAL;

        public SuperstarBAL(IUnitOfWork unitOfWork, ITeamHistoryBAL teamHistoryBAL)
        {
            this.unitOfWork = unitOfWork;
            _teamHistoryBAL = teamHistoryBAL;
        }

        public async Task<IEnumerable<SuperstarDto>> GetSuperstarList()
        {
            var result = await unitOfWork.SuperstarRepository.GetSuperstarList();

            //foreach(var superstar in result)
            //{
            //    var existSuperstar = await unitOfWork.ChampionshipManagementRepository.GetChampionshipManagementBySuperstarId(superstar.SuperstarId);

            //    if (existSuperstar != null)
            //    {
            //        superstar.ChampionshipId = existSuperstar.ChampionshipId;
            //        superstar.ChampionshipTypeId = existSuperstar.ChampionshipTypeId;
            //        superstar.ChampionshipName = existSuperstar.ChampionshipName;
            //    }
            //}
            
            return result;
        }

        public async Task<SuperstarDto> GetSuperstar(Guid id)
        {
            var result = await unitOfWork.SuperstarRepository.GetSuperstar(id);

            //var existSuperstar = await unitOfWork.ChampionshipManagementRepository.GetChampionshipManagementBySuperstarId(result.SuperstarId);

            //if (existSuperstar != null)
            //{
            //    result.ChampionshipId = existSuperstar.ChampionshipId;
            //    result.ChampionshipTypeId = existSuperstar.ChampionshipTypeId;
            //    result.ChampionshipName = existSuperstar.ChampionshipName;
            //}

            return result;
        }

        public async Task<(bool, string)> AddSuperstar(SuperstarDto superstarDto)
        {
            var result = false;
            var message = "";
            
            var existSuperstar = await unitOfWork.SuperstarRepository.GetSuperstarByName(superstarDto.SuperstarName);

            if (existSuperstar == null)
            {
                var superstar = unitOfWork.SuperstarRepository.AddSuperstar(superstarDto);
                result = await unitOfWork.SaveAsync();

                var updateTeamhistory = await _teamHistoryBAL.UpdateTeamHistoryStatusList(superstar.SuperstarId, superstar.TeamId, superstar.IsActive);
            }
            else
            {
                message = "Superstar already exist";
            }
            
            return (result, message);
        }

        public async Task<bool> UpdateSuperstar(SuperstarDto superstarDto)
        {
            unitOfWork.SuperstarRepository.UpdateSuperstar(superstarDto);
            var result = await unitOfWork.SaveAsync();

            var updateTeamhistory = await _teamHistoryBAL.UpdateTeamHistoryStatusList(superstarDto.SuperstarId, superstarDto.TeamId, superstarDto.IsActive);
            return result;
        }

        public async Task<bool> SoftDeleteSuperstar(Guid id)
        {
            unitOfWork.SuperstarRepository.SoftDeleteSuperstar(id);
            return await unitOfWork.SaveAsync();
        }

        public async Task<bool> DeleteSuperstar(Guid id)
        {
            unitOfWork.SuperstarRepository.DeleteSuperstar(id);
            return await unitOfWork.SaveAsync();
        }

    }
}
