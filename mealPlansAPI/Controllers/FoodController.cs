using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Model;
using Repository.Model.Dto.Food;
using Services.Services.IServices;

namespace mealPlansAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;
        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFoods(Pagination pagination)
        {
            try
            {
                var foods = await _foodService.GetAllFoodsAsync(pagination);
                if (foods == null || !foods.Any())
                {
                    return NotFound("Nenhum alimento encontrado");
                }
                return Ok(foods);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno de servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}", Name = "GetFoodById")]
        public async Task<IActionResult> GetFoodById(int id)
        {
            try
            {
                var food = await _foodService.GetFoodByIdAsync(id);

                if (food == null)
                {
                    return NotFound($"Alimento com ID {id} não encontrado");
                }

                return Ok(food);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno de servidor: {ex.Message}");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador,Nutricionista")]
        public async Task<IActionResult> CreateFood([FromBody] CreateFoodDto foodDto)
        {
            try
            {
                var newFood = await _foodService.CreateFoodAsync(foodDto);
                return CreatedAtRoute("GetFoodById", new { id = newFood.Id }, newFood);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno de servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador,Nutricionista")]
        public async Task<IActionResult> UpdateFood(int id, [FromBody] UpdateFoodDto foodDto)
        {
            try
            {
                if (id != foodDto.Id)
                {
                    return BadRequest($"ID {id} do alimento não corresponde ao ID fornecido na URL.");
                }
                await _foodService.UpdateFoodAsync(foodDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno de servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteFood(int id)
        {
            try
            {
                await _foodService.DeleteFoodAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno de servidor: {ex.Message}");
            }
        }
    }
}
