using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2KMUXDAL.Models
{
    public class ChampionshipManagementDto
    {
        public Guid ChampionshipId { get; set; }
        public string ChampionshipName { get; set; }
        public Guid ChampionshipTypeId { get; set; }
        public string ChampionshipTypeName { get; set; }
        public Guid? SuperstarId { get; set; }
        public string SuperstarName { get; set; }
        public Guid ShowId { get; set; }
        public string ShowName { get; set; }
        public int ChampionshipOrder { get; set; }
        public bool IsActive { get; set; }
    }

    public class ChampionsNestedDto
    {
        public Guid ChampionshipId { get; set; }
        public string ChampionshipName { get; set; }
        public Guid ChampionshipShowId { get; set; }
        public Guid ChampionshipTypeId { get; set; }
        public string ChampionshipTypeName { get; set; } 
        public List<ChampionsSuperstar> Superstars { get; set; }
    }

    public class ChampionsSuperstar
    {
        public Guid? TeamId { get; set; }
        public string TeamName { get; set; }
        public Guid? SuperstarId { get; set; }
        public string SuperstarName { get; set; }
    }
}
