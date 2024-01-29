using System.Data;
using System.Runtime.Serialization;
using league_inferno_api.Data;
using league_inferno_api.Interfaces;
using league_inferno_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using league_inferno_api.DTOs;

namespace league_inferno_api.Repository
{
    public class ChampionsRepository(AppDbContext context) : IChampionsRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<ChampionDTO>> GetChampionsAsync()
        {
            var champions = await _context.Champions
                                          .Include(c => c.Abilities)
                                          .ToListAsync();
        
            return champions.Select(champion => new ChampionDTO
            {
                Id = champion.Id,
                Name = champion.Name,
                Description = champion.Description,
                Abilities = champion.Abilities.Select(ability => new AbilityDTO
                {
                    Id = ability.Id,
                    Name = ability.Name,
                    Type = ability.Type,
                    Description = ability.Description
                })
            });
        }

        public async Task<ChampionDTO> GetChampionByIdAsync(int championId)
        {
             var champion = await _context.Champions
                .Include(c => c.Abilities)
                .FirstOrDefaultAsync(c => c.Id == championId);

            if (champion == null)
                return null;

            return new ChampionDTO
            {
                Id = champion.Id,
                Name = champion.Name,
                Description = champion.Description,
                Abilities = champion.Abilities.Select(ability => new AbilityDTO
                {
                    Id = ability.Id,
                    Name = ability.Name,
                    Type = ability.Type,
                    Description = ability.Description
                }).ToList()
            };
        }
    }
}