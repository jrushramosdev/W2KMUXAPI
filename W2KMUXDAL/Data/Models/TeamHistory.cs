using System;
using System.Collections.Generic;

#nullable disable

namespace W2KMUXDAL.Data.Models
{
    public partial class TeamHistory
    {
        public Guid TeamHistoryId { get; set; }
        public Guid? TeamId { get; set; }
        public Guid SuperstarId { get; set; }
        public bool IsActive { get; set; }

        public virtual Team Team { get; set; }
        public virtual Superstar Superstar { get; set; }
    }
}
