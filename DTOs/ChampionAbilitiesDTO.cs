using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace league_inferno_api.DTOs
{
    public class ChampionAbilitiesDTO
    {
            public required string Name { get; set; }
            public required IEnumerable<AbilityDTO> Abilities { get; set; }
    }
}