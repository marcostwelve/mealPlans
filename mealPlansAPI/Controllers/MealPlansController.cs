using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Model.Dto.MealPlan;
using Services.Services.IServices;

namespace mealPlansAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MealPlansController : ControllerBase
    {
        private readonly IMealPlanService _mealPlanService;
        public MealPlansController(IMealPlanService mealPlanService)
        {
            _mealPlanService = mealPlanService;
        }

        [HttpGet("{id}", Name = "GetMealPlanById")]
        public async Task<IActionResult> GetMealPlanById(int id) 
        {
            try
            {
                var mealPlan = await _mealPlanService.GetMealPlanByIdAsync(id);

                if (mealPlan == null)
                {
                    return NotFound($"Plano de refeição com ID {id} não encontrado.");
                }

                return Ok(mealPlan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno de servidor: {ex.Message}");
            }
        }


        [HttpPost]
        [Authorize(Roles = "Adminstrador,Nutricionista")]
        public async Task<IActionResult> CreateMealPlan([FromBody] CreateMealPlanDto mealPlanDto)
        {
           try
           {
                var mealPlan = await _mealPlanService.CreateMealPlanAsync(mealPlanDto);

                if (mealPlan == null)
                {
                    return BadRequest("Não foi possível criar um plano. Verifique se o paciente já existe e se já não há um plano para esta data");
                }

                return CreatedAtAction(nameof(GetMealPlanById), new { id = mealPlan.Id }, mealPlan);
            }
           catch (Exception ex)
           {
                return StatusCode(500, $"Erro interno de servidor {ex.Message}");
           }
        }

        [HttpPost("{id}/foods")]
        [Authorize(Roles = "Nutricionista")]
        public async Task<IActionResult> AddFoodToPlan(int id, [FromBody] AddFoodToPlanDto addFoodToPlanDto)
        {
            try
            {
                var updateMealPlan = await _mealPlanService.AddFoodToMealPlanAsync(id, addFoodToPlanDto);

                if (updateMealPlan == null)
                {
                    return NotFound($"Plano de refeição para o paciente com ID {id} não encontrado para hoje.");
                }
                return Ok(updateMealPlan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno de servidor: {ex.Message}");
            }
        }

    }
}
