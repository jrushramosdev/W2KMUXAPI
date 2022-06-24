using System;
using System.Collections.Generic;

#nullable disable

namespace W2KMUXDAL.Data.Models
{
    public partial class MatchFormat
    {
        public Guid MatchFormatId { get; set; }
        public string MatchFormatName { get; set; }
        public Guid MatchTypeId { get; set; }
        public int TeamsCount { get; set; }
        public int HandicapCount { get; set; }
        public int ParticipantCount { get; set; }
        public int MatchFormatOrder { get; set; }

        public virtual MatchType MatchType { get; set; }
    }
}
