using System;
using System.Collections.Generic;

#nullable disable

namespace W2KMUXDAL.Data.Models
{
    public partial class Superstar
    {
        public Guid SuperstarId { get; set; }
        public string SuperstarName { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public Guid? ShowId { get; set; }
        public Guid? TeamId { get; set; }
        public bool IsInjured { get; set; }
        public bool IsActive { get; set; }

        public virtual Show Show { get; set; }
        public virtual Team Team { get; set; }
    }
}
