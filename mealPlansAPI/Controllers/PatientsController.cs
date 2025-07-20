using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository.Model;
using Repository.Model.Dto.Patient;
using Services.Services.IServices;

namespace mealPlansAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly IMealPlanService _mealPlanService;

        public PatientsController(IPatientService patientService, IMealPlanService mealPlanService)
        {
            _patientService = patientService;
            _mealPlanService = mealPlanService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients([FromQuery] Pagination pagination)
        {
            try
            {
                var patients = await _patientService.GetAllPatientsAsync(pagination);

                if (patients == null)
                {
                    return NotFound("Nenhum paciente encontrado");
                }
                return Ok(patients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno de servidor: {ex.Message}");
            }

        }

        [HttpGet("{id}", Name = "GetPatientById")]
        public async Task<IActionResult> GetPatientById(int id)
        {
            try
            {
                var patient = await _patientService.GetPatientByIdAsync(id);

                if (patient == null)
                {
                    return NotFound($"Paciente com ID {id} não encontrado");
                }

                return Ok(patient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno de servidor: {ex.Message}");
            }
        }

        [HttpGet("{id}/mealplans/today")]
        public async Task<IActionResult> GetTodayMealPlan(int id)
        {
            try 
            {
                var mealPlan = await _mealPlanService.GetTodaysMealPlanByPatientIdAsync(id);

                if (mealPlan == null)
                {
                    return NotFound($"Nenhum plano de refeição encontrado para o paciente com ID {id} hoje.");
                }

                return Ok(mealPlan);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno de servidor: {ex.Message}");
            }
        }

        [HttpPost]
        [Authorize(Roles = "Administrador,Nutricionista")]
        public async Task<IActionResult> CreatePatient([FromBody] CreatePatientDto createPatientDto)
        {
            try
            {
                var newPatient = await _patientService.CreatePatientAsync(createPatientDto);

                return CreatedAtAction(nameof(GetPatientById), new { Id = newPatient.Id }, newPatient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno de servidor: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador,Nutricionista")]
        public async Task<IActionResult> UpdatePatientAsync(int id, [FromBody] UpdatePatientDto updatePatientDto)
        {
            try
            {
                await _patientService.UpdatePatientAsync(updatePatientDto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno de servidor: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeletePatient(int id) 
        {
            try
            {
                await _patientService.RemovePatientAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno de servidor: {ex.Message}");
            }
        }
    }
}
