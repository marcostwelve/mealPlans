using Microsoft.AspNetCore.Mvc;
using Repository.Model.Dto.Auth.Dtos;
using Repository.Repository.IUserRepository;
using Services.Services.IServices;

namespace mealPlansAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        private readonly IAuthService _authService;
        public AuthController(IUserRepository userRepository, ITokenService tokenService, IAuthService authService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto login)
        {
            try
            {
                var result = await _authService.LoginAsync(login);

                if (!result.IsSuccess)
                {
                    return Unauthorized($"{result.Message}");
                }


                return Ok(new { Token = result.Token });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno de servidor: {ex.Message}");
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto register)
        {
            try
            {
                var result = await _authService.RegisterAsync(register);

                if (!result.IsSuccess)
                {
                    return BadRequest("Usuário já existe com este email");
                }

                return Ok(new { Message = result.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno de servidor: {ex.Message}");
            }
        }
    }
}
