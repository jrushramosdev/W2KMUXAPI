using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace W2KMUXDAL.Models
{
    public class MatchTitleManagementDto
    {
        public Guid MatchTitleId { get; set; }
        public string MatchTitleName { get; set; }
        public int MatchTitleOrder { get; set; }
    }
}
