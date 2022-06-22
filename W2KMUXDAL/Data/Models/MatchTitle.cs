using System;
using System.Collections.Generic;

#nullable disable

namespace W2KMUXDAL.Data.Models
{
    public partial class MatchTitle
    {
        public Guid MatchTitleId { get; set; }
        public string MatchTitleName { get; set; }
        public int MatchTitleOrder { get; set; }
    }
}
