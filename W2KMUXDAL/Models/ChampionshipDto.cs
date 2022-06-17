using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2KMUXDAL.Models
{
    public class ChampionshipDto
    {
        public Guid ChampionshipId { get; set; }
        public string ChampionshipName { get; set; }
        public Guid ChampionshipTypeId { get; set; }
        public Guid? SuperstarId { get; set; }
        public Guid? ShowId { get; set; }
        public int ChampionshipOrder { get; set; }
        public bool IsActive { get; set; }
    }
}
