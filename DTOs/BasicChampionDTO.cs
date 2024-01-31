using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using league_inferno_api.Models;

namespace league_inferno_api.DTOs
{
    public class BasicChampionDTO
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
    }
}