using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace league_inferno_api.DTOs
{
    public class ChampionAbilitiesDTO
    {
            public string Name { get; set; }
            public IEnumerable<AbilityDTO> Abilities { get; set; }
    }
}