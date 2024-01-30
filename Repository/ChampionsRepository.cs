using System.Data;
using System.Threading.Tasks;
using league_inferno_api.Data;
using league_inferno_api.DTOs;
using league_inferno_api.Interfaces;
using Microsoft.EntityFrameworkCore;

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

            if (champions == null)
            {
                throw new Exception($"No champions exist.");
            }

            return champions.Select(champion => new ChampionDTO
            {
                Id = champion.Id,
                Name = champion.Name,
                Description = champion.Description
            });
        }

        public async Task<ChampionDTO> GetChampionByIdAsync(int championId)
        {
             var champion = await _context.Champions
                .Include(c => c.Abilities)
                .FirstOrDefaultAsync(c => c.Id == championId);

            if (champion == null)
            {
                throw new Exception($"Champion with Id {championId} not found.");
            }
            return new ChampionDTO
            {
                Id = champion.Id,
                Name = champion.Name,
                Description = champion.Description
            };
        }
    }
}