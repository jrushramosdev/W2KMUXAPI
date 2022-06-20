using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2KMUXDAL.Models
{
    public class TeamHistoryDto
    {
        public Guid TeamHistoryId { get; set; }
        public Guid? TeamId { get; set; }
        public string TeamName { get; set; }
        public Guid SuperstarId { get; set; }
        public string SuperstarName { get; set; }
        public bool IsActive { get; set; }
    }

    public class TeamHistoryNestedDto
    {
        public Guid? TeamId { get; set; }
        public string TeamName { get; set; }
        public string TeamGender { get; set; }
        public string TeamRole { get; set; }
        public Guid? TeamShowId { get; set; }
        public int TeamCount { get; set; }
        public string TeamChampionship { get; set; }
        public List<TeamHistorySuperstar> Superstar { get; set; }
    }

    public class TeamHistorySuperstar
    {
        public Guid SuperstarId { get; set; }
        public string SuperstarName { get; set; }
        public string SuperstarGender { get; set; }
        public string SuperstarRole{ get; set; }
        public Guid? SuperstarShowId { get; set; }
        public Guid? ChampionshipId { get; set; }
        public Guid? ChampionshipTypeId { get; set; }
        public string ChampionshipName { get; set; }
        public bool IsActive { get; set; }
    }
}
