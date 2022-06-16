using System;
using System.Collections.Generic;

#nullable disable

namespace W2KMUXDAL.Data.Models
{
    public partial class Ppv
    {
        public Guid PPVId { get; set; }
        public string PPVName { get; set; }
        public int PPVMonth { get; set; }
        public int PPVOrder { get; set; }
        public Guid ShowId { get; set; }
        public bool IsActive { get; set; }

        public virtual Show Show { get; set; }
    }
}
