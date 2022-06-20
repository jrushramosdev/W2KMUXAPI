using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2KMUXDAL.Models
{
    public class SuperstarDto
    {
        public Guid SuperstarId { get; set; }
        public string SuperstarName { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public Guid? ShowId { get; set; }
        public string ShowName { get; set; }
        public Guid? TeamId { get; set; }
        public string TeamName { get; set; }
        public Guid? ChampionshipId { get; set; }
        public Guid? ChampionshipTypeId { get; set; }
        public string ChampionshipName { get; set; }
        public bool IsInjured { get; set; }
        public bool IsActive { get; set; }
    }
}
