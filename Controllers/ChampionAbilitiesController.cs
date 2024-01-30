using league_inferno_api.Repository;
using league_inferno_api.Data;
using Microsoft.AspNetCore.Mvc;
using league_inferno_api.Interfaces;
using league_inferno_api.Models;
using System.Threading.Tasks;
using league_inferno_api.DTOs;

namespace league_inferno_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChampionAbilitiesController(IChampionAbilitiesRepository champAbilitiesRep) : ControllerBase
    {
        private readonly IChampionAbilitiesRepository _champAbilitiesRep = champAbilitiesRep;

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ChampionAbilitiesDTO>))]
        public async Task<IActionResult> GetChampionAbilitiesByIdAsync(int id)
        {
            var champion = await _champAbilitiesRep.GetChampionAbilitiesByIdAsync(id);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(champion); 
        }
    }
}