using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            try
            {
                var patients = await _patientService.GetAllPatientsAsync();

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
        public async Task<IActionResult> UpdatePatientAsync([FromBody] UpdatePatientDto updatePatientDto)
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
