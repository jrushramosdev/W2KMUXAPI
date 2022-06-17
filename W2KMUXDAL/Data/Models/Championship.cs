using System;
using System.Collections.Generic;

#nullable disable

namespace W2KMUXDAL.Data.Models
{
    public partial class Championship
    {
        public Guid ChampionshipId { get; set; }
        public string ChampionshipName { get; set; }
        public Guid ChampionshipTypeId { get; set; }
        public Guid? SuperstarId { get; set; }
        public Guid ShowId { get; set; }
        public int ChampionshipOrder { get; set; }
        public bool IsActive { get; set; }

        public virtual ChampionshipType ChampionshipType { get; set; }
        public virtual Superstar Superstar { get; set; }
        public virtual Show Show { get; set; }
    }
}
