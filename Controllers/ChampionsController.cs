using league_inferno_api.Repository;
using league_inferno_api.Data;
using Microsoft.AspNetCore.Mvc;
using league_inferno_api.Interfaces;
using league_inferno_api.Models;
using System.Threading.Tasks;

namespace league_inferno_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChampionsController(IChampionsRepository champRep) : ControllerBase
    {
        private readonly IChampionsRepository _champRep = champRep;

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Champion>))]
        public async Task<IActionResult> GetChampions()
        {
            var champions = await _champRep.GetChampionsAsync();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            return Ok(champions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetChampionById(int id)
        {
            var champion = await _champRep.GetChampionByIdAsync(id);

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(champion); 
        }
    }
}