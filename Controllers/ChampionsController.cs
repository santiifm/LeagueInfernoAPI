using Microsoft.AspNetCore.Mvc;
using league_inferno_api.Interfaces;
using league_inferno_api.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace league_inferno_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChampionsController(IChampionsRepository champRep) : ControllerBase
    {
        private readonly IChampionsRepository _champRep = champRep;

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ChampionDTO>))]
        public async Task<IActionResult> GetChampions()
        {
            var champions = await _champRep.GetChampionsAsync();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            return Ok(champions);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ChampionDTO))]
        public async Task<IActionResult> GetChampionById(int id)
        {
            var champion = await _champRep.GetChampionByIdAsync(id);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(champion);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("create")]
        [ProducesResponseType(200, Type = typeof(ChampionDTO))]
        public async Task<IActionResult> AddChampion(BasicChampionDTO champion)
        {

            var newChampion = await _champRep.AddChampionAsync(champion);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(newChampion);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(String))]
        public async Task<IActionResult> DeleteChampion(int id)
        {
            await _champRep.DeleteChampionAsync(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return Ok("The champion has been deleted successfully");
        }
    }
}