using System;
using System.Collections.Generic;

#nullable disable

namespace W2KMUXDAL.Data.Models
{
    public partial class Show
    {
        public Show()
        {
            Ppvs = new HashSet<Ppv>();
        }

        public Guid ShowId { get; set; }
        public string ShowName { get; set; }
        public int ShowOrder { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Ppv> Ppvs { get; set; }
    }
}
