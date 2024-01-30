using league_inferno_api.DTOs;

namespace league_inferno_api.Interfaces
{
    public interface IChampionAbilitiesRepository
    {
        Task<ChampionAbilitiesDTO> GetChampionAbilitiesByIdAsync(int ChampionId);
    }
}