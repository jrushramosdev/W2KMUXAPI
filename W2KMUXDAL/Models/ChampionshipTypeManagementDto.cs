using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2KMUXDAL.Models
{
    public class ChampionshipTypeManagementDto
    {
        public Guid ChampionshipTypeId { get; set; }
        public string ChampionshipTypeName { get; set; }
        public bool IsActive { get; set; }
        public int ChampionshipTypeOrder { get; set; }
    }
}
