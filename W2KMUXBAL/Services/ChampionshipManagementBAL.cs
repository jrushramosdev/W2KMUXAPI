using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using W2KMUXDAL.Data;
using W2KMUXDAL.Models;

namespace W2KMUXBAL.Services
{
    public class ChampionshipManagementBAL : IChampionshipManagementBAL
    {
        private readonly IUnitOfWork unitOfWork;

        public ChampionshipManagementBAL(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<ChampionshipManagementDto>> GetChampionshipManagementList()
        {
            var result = await unitOfWork.ChampionshipManagementRepository.GetChampionshipManagementList();
            return result;
        }

        public async Task<ChampionshipManagementDto> GetChampionshipManagement(Guid id)
        {
            var result = await unitOfWork.ChampionshipManagementRepository.GetChampionshipManagement(id);
            return result;
        }

        public async Task<bool> AddChampionshipManagement(ChampionshipManagementDto championshipTypeManagementDto)
        {
            unitOfWork.ChampionshipManagementRepository.AddChampionshipManagement(championshipTypeManagementDto);
            return await unitOfWork.SaveAsync();
        }

        public async Task<bool> UpdateChampionshipManagement(ChampionshipManagementDto championshipTypeManagementDto)
        {
            unitOfWork.ChampionshipManagementRepository.UpdateChampionshipManagement(championshipTypeManagementDto);
            return await unitOfWork.SaveAsync();
        }

        public async Task<bool> SoftDeleteChampionshipManagement(Guid id)
        {
            unitOfWork.ChampionshipManagementRepository.SoftDeleteChampionshipManagement(id);
            return await unitOfWork.SaveAsync();
        }

        public async Task<bool> DeleteChampionshipManagement(Guid id)
        {
            unitOfWork.ChampionshipManagementRepository.DeleteChampionshipManagement(id);
            return await unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ChampionsNestedDto>> GetChampionsNestedList()
        {
            List<ChampionsNestedDto> championsNestedDto = new List<ChampionsNestedDto>();
            
            SuperstarDto superstarDto = new SuperstarDto();

            var championship = await unitOfWork.ChampionshipManagementRepository.GetChampionshipManagementList(); // Get Championship
            championship = championship.Where(f => f.IsActive == true).ToList(); // Filter by isActive == true

            var championshipName = ""; 
            Guid showId = Guid.NewGuid();

            //** This function need clean record for tag team, royal rumble etc. tagging *//
            foreach (var champion in championship)
            {
                List<ChampionsSuperstar> championsSuperstar = new List<ChampionsSuperstar>();
                Guid? superstarId = Guid.NewGuid();
                superstarId = champion.SuperstarId;
                var tempChampionsSuperstar = await GetChampionsSuperstarData(superstarId); // Get Superstar
                championsSuperstar.Add(tempChampionsSuperstar); // Insert Superstar Info

                if (champion.ChampionshipName == championshipName && champion.ShowId == showId)
                {
                    championsNestedDto.Where(m => m.ChampionshipName == champion.ChampionshipName && m.ChampionshipShowId == champion.ShowId)
                        .FirstOrDefault().Superstars.Add(tempChampionsSuperstar);
                }
                else
                {
                    ChampionsNestedDto tempChampionsNested = new ChampionsNestedDto()
                    {
                        ChampionshipId = champion.ChampionshipId,
                        ChampionshipName = champion.ChampionshipName,
                        ChampionshipShowId = champion.ShowId,
                        ChampionshipTypeId = champion.ChampionshipTypeId,
                        ChampionshipTypeName = champion.ChampionshipTypeName,
                        Superstars = championsSuperstar
                    };

                    championsNestedDto.Add(tempChampionsNested);
                }

                championshipName = champion.ChampionshipName;
                showId = champion.ShowId;
            }

            return championsNestedDto;
        }

        public async Task<ChampionsSuperstar> GetChampionsSuperstarData(Guid? SuperstarId)
        {
            ChampionsSuperstar result = new ChampionsSuperstar();

            if (SuperstarId != null)
            {
                var superstarDto = await unitOfWork.SuperstarRepository.GetSuperstar(SuperstarId.Value); // Get Superstar

                result.TeamId = superstarDto.TeamId == null? null : superstarDto.TeamId;
                result.TeamName = superstarDto.TeamName;
                result.SuperstarId = superstarDto.SuperstarId;
                result.SuperstarName = superstarDto.SuperstarName;
            };

            return result;
        }

        public List<TeamHistoryNestedDto> CleanTeamHistorySuperstarData(List<TeamHistoryNestedDto> teamHistoryNestedDto)
        {
            if (teamHistoryNestedDto != null)
            {
                foreach (var teamhistory in teamHistoryNestedDto)
                {
                    var gender = "Male";
                    var role = "Face";
                    var championship = "";
                    Guid? showid = null;

                    int malecount = 0;
                    int femalecount = 0;
                    int facecount = 0;
                    int heelcount = 0;

                    foreach (var superstar in teamhistory.Superstar)
                    {
                        if (superstar.SuperstarGender.ToLower() == "male")
                        {
                            malecount = malecount + 1;
                        }
                        else
                        {
                            femalecount = femalecount + 1;
                        }

                        if (superstar.SuperstarRole.ToLower() == "face")
                        {
                            facecount = facecount + 1;
                        }
                        else
                        {
                            heelcount = heelcount + 1;
                        }

                        if (superstar.ChampionshipTypeId == new Guid("C0912FE2-F8B6-4D35-88EA-48733A9A343F")) // TAG TEAM
                        {
                            championship = superstar.ChampionshipName;

                        }

                        showid = superstar.SuperstarShowId;
                    }

                    if (femalecount > malecount)
                    {
                        gender = "Female";
                    }

                    if (heelcount > facecount)
                    {
                        role = "Heel";
                    }

                    teamhistory.TeamCount = teamhistory.Superstar.Count();
                    teamhistory.TeamGender = gender;
                    teamhistory.TeamRole = role;
                    teamhistory.TeamChampionship = championship;
                    teamhistory.TeamShowId = showid;
                }
            }

            return teamHistoryNestedDto;
        }
    }
}
