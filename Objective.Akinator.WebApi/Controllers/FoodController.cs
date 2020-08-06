using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Objective.Akinator.WebApi.Models;
using Objective.Akinator.WebApi.Services;

namespace Objective.Akinator.WebApi.Controllers
{
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly FoodService _foodService;

        public FoodController(FoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet("/")]
        public async Task<IActionResult> StartGame()
        {
            return Ok(await _foodService.StartGame());
        }

        [HttpPost("/learn/{idParent}/right")]
        public async Task<IActionResult> LearnRight([FromBody] Food food, [FromRoute] string idParent)
        {
            await _foodService.LearnRight(food, idParent).ConfigureAwait(false);
            return Ok(food);
        }


        [HttpPost("/learn/{idParent}/left")]
        public async Task<IActionResult> LearnLeft([FromBody] Food food, [FromRoute] string idParent)
        {
            await _foodService.LearnLeft(food, idParent).ConfigureAwait(false);
            return Ok(food);
        }

        [HttpGet("/{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            return Ok(await _foodService.GetById(id).ConfigureAwait(false));
        }        
    }
}