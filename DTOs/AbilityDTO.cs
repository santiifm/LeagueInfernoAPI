using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace league_inferno_api.DTOs
{
    public class AbilityDTO
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; }
        public required string Description { get; set; }
    }
}