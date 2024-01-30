using league_inferno_api.DTOs;

namespace league_inferno_api.Interfaces
{
    public interface IChampionsRepository
    {
        Task<IEnumerable<ChampionDTO>> GetChampionsAsync();
        Task<ChampionDTO> GetChampionByIdAsync(int ChampionId);
    }
}