using System.Data;
using System.Threading.Tasks;
using league_inferno_api.Data;
using league_inferno_api.DTOs;
using league_inferno_api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace league_inferno_api.Repository
{
    public class ChampionAbilitiesRepository(AppDbContext context) : IChampionAbilitiesRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<ChampionAbilitiesDTO> GetChampionAbilitiesByIdAsync(int championId)
        {
            var champion = await _context.Champions
                                         .Include(c => c.Abilities)
                                         .FirstOrDefaultAsync(c => c.Id == championId);

            if (champion == null)
            {
                throw new Exception($"Abilities for the champion with Id {championId} not found.");
            }

            return new ChampionAbilitiesDTO
            {
                Name = champion.Name,
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