using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2KMUXDAL.Models
{
    public class PPVMatchDto
    {
        public Guid PPVMatchId { get; set; }
        public string PPVMatchName { get; set; }
        public int PPVMatchCount { get; set; }
        public int PPVMatchOrder { get; set; }
        public Guid PPVId { get; set; }
        public string PPVName { get; set; }
        public Guid ShowId { get; set; }
        public string ShowName { get; set; }
        public Guid MatchTitleId { get; set; }
        public Guid MatchFormatId { get; set; }
        public bool IsDone { get; set; }
    }

    public class PPVMatchLatestDto
    {
        public int PPVMatchCount { get; set; }
        public Guid PPVId { get; set; }
        public string PPVName { get; set; }
        public bool IsDone { get; set; }
    }

    public class PPVMatchNestedDto
    {
        public Guid PPVMatchId { get; set; }
        public string PPVMatchName { get; set; }
        public int PPVMatchCount { get; set; }
        public int PPVMatchOrder { get; set; }
        public Guid PPVId { get; set; }
        public string PPVName { get; set; }
        public Guid ShowId { get; set; }
        public string ShowName { get; set; }
        public Guid MatchTitleId { get; set; }
        public Guid MatchFormatId { get; set; }
        public Guid MatchTypeId { get; set; }
        public bool IsDone { get; set; }
        public List<PPVMatchChampionshipDto> Championship { get; set; }
        public List<PPVMatchTeamDto> Team { get; set; }
    }

    public class PPVMatchChampionshipDto
    {
        public Guid PPVMatchChampionshipId { get; set; }
        public Guid PPVMatchId { get; set; }
        public Guid ChampionshipId { get; set; }
        public string ChampionshipName { get; set; }
    }

    public class PPVMatchTeamDto
    {
        public Guid PPVMatchTeamId { get; set; }
        public Guid PPVMatchId { get; set; }
        public bool isChampion { get; set; }
        public bool isWinner { get; set; }
        public List<PPVMatchParticipantDto> Participant { get; set; }
    }

    public class PPVMatchParticipantDto
    {
        public Guid PPVMatchParticipantId { get; set; }
        public Guid PPVMatchTeamId { get; set; }
        public Guid SuperstarId { get; set; }
        public string SuperstarName { get; set; }
    }

    #region ADD PPV MATCH DTO
    public class AddPPVMatchNestedDto
    {
        public string PPVMatchName { get; set; }
        public int PPVMatchCount { get; set; }
        public int PPVMatchOrder { get; set; }
        public Guid PPVId { get; set; }
        public Guid ShowId { get; set; }
        public Guid MatchTitleId { get; set; }
        public Guid MatchFormatId { get; set; }
        public List<AddPPVMatchChampionshipDto> Championship { get; set; }
        public List<AddPPVMatchTeamDto> Team { get; set; }
    }

    public class AddPPVMatchChampionshipDto
    {
        public Guid? ChampionshipId { get; set; }
    }

    public class AddPPVMatchTeamDto
    {
        public bool IsChampion { get; set; }
        public List<AddPPVMatchParticipantDto> Participant { get; set; }
    }

    public class AddPPVMatchParticipantDto
    {
        public Guid SuperstarId { get; set; }
    }
    #endregion
}
