using System;
using System.Collections.Generic;

#nullable disable

namespace W2KMUXDAL.Data.Models
{
    public partial class PPVMatchChampionship
    {
        public Guid PPVMatchChampionshipId { get; set; }
        public Guid PPVMatchId { get; set; }
        public Guid ChampionshipId { get; set; }

        public virtual PPVMatch PPVMatch { get; set; }
        public virtual Championship Championship { get; set; }
    }
}
