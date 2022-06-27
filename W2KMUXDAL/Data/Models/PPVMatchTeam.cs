using System;
using System.Collections.Generic;

#nullable disable

namespace W2KMUXDAL.Data.Models
{
    public partial class PPVMatchTeam
    {
        public Guid PPVMatchTeamId { get; set; }
        public Guid PPVMatchId { get; set; }
        public bool isChampion { get; set; }
        public bool isWinner { get; set; }

        public virtual PPVMatch PPVMatch { get; set; }
    }
}
