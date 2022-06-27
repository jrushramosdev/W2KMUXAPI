using System;
using System.Collections.Generic;

#nullable disable

namespace W2KMUXDAL.Data.Models
{
    public partial class PPVMatch
    {
        public Guid PPVMatchId { get; set; }
        public string PPVMatchName { get; set; }
        public int PPVMatchCount { get; set; }
        public int PPVMatchOrder { get; set; }
        public Guid PPVId { get; set; }
        public Guid ShowId { get; set; }
        public Guid MatchTitleId { get; set; }
        public Guid MatchFormatId { get; set; }
        public bool isDone { get; set; }

        public virtual Ppv Ppv { get; set; }
        public virtual Show Show { get; set; }
        public virtual MatchTitle MatchTitle { get; set; }
        public virtual MatchFormat MatchFormat { get; set; }
    }
}
