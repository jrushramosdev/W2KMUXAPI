using System;
using System.Collections.Generic;

#nullable disable

namespace W2KMUXDAL.Data.Models
{
    public partial class MatchType
    {
        public Guid MatchTypeId { get; set; }
        public string MatchTypeName { get; set; }
        public int MatchTypeOrder { get; set; }
    }
}
