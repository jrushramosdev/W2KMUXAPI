using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2KMUXDAL.Models
{
    public class MatchTypeManagementDto
    {
        public Guid MatchTypeId { get; set; }
        public string MatchTypeName { get; set; }
        public int MatchTypeOrder { get; set; }
    }
}
