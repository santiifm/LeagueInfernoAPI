using System.Data;
using System.Threading.Tasks;
using league_inferno_api.Data;
using league_inferno_api.DTOs;
using league_inferno_api.Interfaces;
using league_inferno_api.Models;
using Microsoft.EntityFrameworkCore;

namespace league_inferno_api.Repository
{
    public class ChampionsRepository(AppDbContext context) : IChampionsRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<IEnumerable<ChampionDTO>> GetChampionsAsync()
        {
            var champions = await _context.Champions.ToListAsync();

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
                Description = champion.Description,
                Abilities = champion.Abilities?.Select(ability => new AbilityDTO
                {
                    Id = ability.Id,
                    Name = ability.Name,
                    Type = ability.Type,
                    Description = ability.Description
                })
            };
        }
            
        public async Task<ChampionDTO> AddChampionAsync(BasicChampionDTO champion)
        {
            var champ = new Champion
            {
                Name = champion.Name,
                Description = champion.Description,
            };

            try
            {
                await _context.Champions.AddAsync(champ);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw new Exception($"A problem ocurred during the DB transaction");
            }

            return new ChampionDTO
            {
                Id = champ.Id,
                Name = champ.Name,
                Description = champ.Description
            };
        }

        public async Task DeleteChampionAsync(int championId)
        {
            var champion = await _context.Champions.FirstOrDefaultAsync(c => c.Id == championId); 

            if (champion == null)
            {
                throw new Exception($"A champion with that Id doesn't exist.");
            }
            _context.Champions.Remove(champion);
            await _context.SaveChangesAsync();
        }
    }
}