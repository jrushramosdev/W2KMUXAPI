using System;
using System.Collections.Generic;

#nullable disable

namespace W2KMUXDAL.Data.Models
{
    public partial class ChampionshipType
    {
        public Guid ChampionshipTypeId { get; set; }
        public string ChampionshipTypeName { get; set; }
        public bool IsActive { get; set; }
        public int ChampionshipTypeOrder { get; set; }
    }
}
