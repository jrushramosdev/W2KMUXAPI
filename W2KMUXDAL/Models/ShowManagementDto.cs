using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2KMUXDAL.Models
{
    public class ShowManagementDto
    {
        public Guid ShowId { get; set; }
        public string ShowName { get; set; }
        public int ShowOrder { get; set; }
        public bool IsActive { get; set; }
    }
}
