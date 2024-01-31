using league_inferno_api.DTOs;
using league_inferno_api.Models;

namespace league_inferno_api.Interfaces
{
    public interface IChampionsRepository
    {
        Task<IEnumerable<ChampionDTO>> GetChampionsAsync();
        Task<ChampionDTO> GetChampionByIdAsync(int championId);
        Task<ChampionDTO> AddChampionAsync(BasicChampionDTO champion);
        Task DeleteChampionAsync(int championId);
    }
}