using System;
using System.Collections.Generic;

#nullable disable

namespace W2KMUXDAL.Data.Models
{
    public partial class Team
    {
        public Guid TeamId { get; set; }
        public string TeamName { get; set; }
        public bool IsActive { get; set; }
    }
}
