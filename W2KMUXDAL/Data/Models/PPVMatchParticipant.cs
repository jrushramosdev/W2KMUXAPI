using System;
using System.Collections.Generic;

#nullable disable

namespace W2KMUXDAL.Data.Models
{
    public partial class PPVMatchParticipant
    {
        public Guid PPVMatchParticipantId { get; set; }
        public Guid PPVMatchTeamId { get; set; }
        public Guid SuperstarId { get; set; }

        public virtual PPVMatchTeam PPVMatchTeam { get; set; }
        public virtual Superstar Superstar { get; set; }
    }
}
