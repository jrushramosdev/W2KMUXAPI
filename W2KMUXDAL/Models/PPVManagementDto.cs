using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2KMUXDAL.Models
{
    public class PPVManagementDto
    {
        public Guid PPVId { get; set; }
        public string PPVName { get; set; }
        public int PPVMonth { get; set; }
        public int PPVOrder { get; set; }
        public Guid ShowId { get; set; }
        public string ShowName { get; set; }
        public bool IsActive { get; set; }
    }
}
