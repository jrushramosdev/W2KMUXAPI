using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2KMUXDAL.Models
{
    public class MatchFormatManagementDto
    {
        public Guid MatchFormatId { get; set; }
        public string MatchFormatName { get; set; }
        public Guid MatchTypeId { get; set; }
        public string MatchTypeName { get; set; }
        public int TeamsCount { get; set; }
        public int HandicapCount { get; set; }
        public int ParticipantCount { get; set; }
        public int MatchFormatOrder { get; set; }
    }
}
