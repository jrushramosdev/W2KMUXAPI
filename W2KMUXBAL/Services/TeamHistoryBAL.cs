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
    public class TeamHistoryBAL : ITeamHistoryBAL
    {
        private readonly IUnitOfWork unitOfWork;
        //private readonly ISuperstarBAL _superstarBAL;

        public TeamHistoryBAL(IUnitOfWork unitOfWork)
        //public TeamHistoryBAL(IUnitOfWork unitOfWork, ISuperstarBAL superstarBAL)
        {
            this.unitOfWork = unitOfWork;
            //_superstarBAL = superstarBAL;
        }

        public async Task<IEnumerable<TeamHistoryDto>> GetTeamHistoryList()
        {
            var result = await unitOfWork.TeamHistoryRepository.GetTeamHistoryList();
            return result;
        }

        public async Task<IEnumerable<TeamHistoryDto>> GetTeamHistoryListById(Guid superstarid)
        {
            var result = await unitOfWork.TeamHistoryRepository.GetTeamHistoryListBySuperstarId(superstarid);
            return result;
        }

        public async Task<TeamHistoryDto> GetTeamHistory(Guid id)
        {
            var result = await unitOfWork.TeamHistoryRepository.GetTeamHistory(id);
            return result;
        }

        public async Task<bool> AddTeamHistory(TeamHistoryDto teamHistoryDto)
        {
            unitOfWork.TeamHistoryRepository.AddTeamHistory(teamHistoryDto);
            return await unitOfWork.SaveAsync();
        }

        public async Task<bool> UpdateTeamHistory(TeamHistoryDto teamHistoryDto)
        {
            unitOfWork.TeamHistoryRepository.UpdateTeamHistory(teamHistoryDto);
            return await unitOfWork.SaveAsync();
        }

        public async Task<bool> SoftDeleteTeamHistory(Guid id)
        {
            unitOfWork.TeamHistoryRepository.SoftDeleteTeamHistory(id);
            return await unitOfWork.SaveAsync();
        }

        public async Task<bool> DeleteTeamHistory(Guid id)
        {
            unitOfWork.TeamHistoryRepository.DeleteTeamHistory(id);
            return await unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<TeamHistoryNestedDto>> GetTeamHistoryNestedList(bool isactiveonly)
        {
            List<TeamHistoryNestedDto> teamHistoryNestedDto = new List<TeamHistoryNestedDto>();
           
            var teams = await unitOfWork.TeamManagementRepository.GetTeamManagementList(); // Get Teams
            if (isactiveonly)
            {
                teams = teams.Where(f => f.IsActive == true).ToList(); // Filter by isActive == true
            }
            
            foreach (var team in teams)
            {
                var teamhistorylist = await unitOfWork.TeamHistoryRepository.GetTeamHistoryListByTeamId(team.TeamId); // Get Team History List
                if (isactiveonly)
                {
                    teamhistorylist = teamhistorylist.Where(h => h.IsActive == true).ToList();
                }

                foreach (var teamhistory in teamhistorylist)
                {
                    bool contains = teamHistoryNestedDto.Any(m => m.TeamId == team.TeamId); // Check if Final team history nested data has team id
                    if (!contains) // Insert new nested data
                    {
                        List<TeamHistorySuperstar> teamHistorySuperstar = new List<TeamHistorySuperstar>();
                        var tempTeamHistorySuperstar = await GetTeamHistorySuperstarData(teamhistory.SuperstarId, teamhistory.IsActive);

                        teamHistorySuperstar.Add(tempTeamHistorySuperstar); // Insert Superstar Info

                        TeamHistoryNestedDto tempTeamHistoryNested = new TeamHistoryNestedDto()
                        {
                            TeamId = team.TeamId,
                            TeamName = team.TeamName,
                            Superstar = teamHistorySuperstar
                        };

                        teamHistoryNestedDto.Add(tempTeamHistoryNested); // Insert Nested Info
                    }
                    else
                    {
                        var tempTeamHistorySuperstar = await GetTeamHistorySuperstarData(teamhistory.SuperstarId, teamhistory.IsActive);

                        teamHistoryNestedDto.Where(m => m.TeamId == team.TeamId).FirstOrDefault().Superstar.Add(tempTeamHistorySuperstar); // Check if Final team history nested data has team id
                    }
                }   
            }

            teamHistoryNestedDto = CleanTeamHistorySuperstarData(teamHistoryNestedDto);

            return teamHistoryNestedDto;
        }

        public async Task<TeamHistorySuperstar> GetTeamHistorySuperstarData(Guid SuperstarId, bool teamHistoryIsActive)
        {
             var superstar = await unitOfWork.SuperstarRepository.GetSuperstar(SuperstarId); // Get Superstar
            //var superstar = await _superstarBAL.GetSuperstar(SuperstarId); // Get Superstar

            TeamHistorySuperstar result = new TeamHistorySuperstar()
            {
                SuperstarId = superstar.SuperstarId,
                SuperstarName = superstar.SuperstarName,
                SuperstarGender = superstar.Gender,
                SuperstarRole = superstar.Role,
                SuperstarShowId = superstar.ShowId,
                ChampionshipId = superstar.ChampionshipId,
                ChampionshipTypeId = superstar.ChampionshipTypeId,
                ChampionshipName = superstar.ChampionshipName,
                IsActive = teamHistoryIsActive
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

        public async Task<bool> UpdateTeamHistoryStatusList(Guid superstarid, Guid? teamid, bool superstarisactive)
        {
            TeamHistoryDto teamHistoryDto = new TeamHistoryDto
            {
                TeamHistoryId = new Guid(),
                TeamId = teamid,
                SuperstarId = superstarid,
                IsActive = false
            };

            var result = false;
            var teamhistory = await unitOfWork.TeamHistoryRepository.GetTeamHistoryListBySuperstarId(superstarid);

            if (teamhistory.Count() > 0)
            {
                unitOfWork.TeamHistoryRepository.UpdateTeamHistoryStatusList(superstarid, false);
                result = await unitOfWork.SaveAsync();

                if (teamid != null)
                {
                    var teamIdExist = false;
                    Guid teamHistoryId = new Guid();

                    foreach (var team in teamhistory)
                    {
                        if (teamid == team.TeamId)
                        {
                            teamIdExist = true;
                            teamHistoryId = team.TeamHistoryId;
                        }
                    }

                    if (teamIdExist)
                    {
                        teamHistoryDto.TeamHistoryId = teamHistoryId;

                        if (superstarisactive)
                        {
                            teamHistoryDto.IsActive = true;
                        }

                        unitOfWork.TeamHistoryRepository.UpdateTeamHistory(teamHistoryDto);
                    }
                    else
                    {
                        if (superstarisactive)
                        {
                            teamHistoryDto.IsActive = true;
                        }

                        unitOfWork.TeamHistoryRepository.AddTeamHistory(teamHistoryDto);
                    }

                    result = await unitOfWork.SaveAsync();
                }
            }
            else
            {
                if (teamid != null)
                {
                    if (superstarisactive)
                    {
                        teamHistoryDto.IsActive = true;
                    }

                    unitOfWork.TeamHistoryRepository.AddTeamHistory(teamHistoryDto);
                    result = await unitOfWork.SaveAsync();
                }
            }

            return result;
        }
    }
}
