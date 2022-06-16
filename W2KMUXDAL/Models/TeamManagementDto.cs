using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2KMUXDAL.Models
{
    public class TeamManagementDto
    {
        public Guid TeamId { get; set; }
        public string TeamName { get; set; }
        public bool IsActive { get; set; }
    }
}
