using Repository.Model.Dto;
using Repository.Model.Dto.Auth.Dtos;
using Repository.Repository.IUserRepository;
using Services.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        public AuthService(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<LoginResult> LoginAsync(LoginDto login)
        {
            try
            {
                var user = await _userRepository.GetUserByEmailAsync(login.Email);

                if (user == null)
                {
                    return new LoginResult { IsSuccess = false, Message = "Email não encontrado" };
                }

                var isPasswordValid = BCrypt.Net.BCrypt.Verify(login.Password, user.PasswordHash);

                if (!isPasswordValid)
                {
                    return new LoginResult {IsSuccess = false, Message = "Senha inválida" };
                }
                var token = _tokenService.GenerateToken(user);

                return new LoginResult { IsSuccess = true, Token = token };
            }
            catch (Exception ex)
            {
                return new LoginResult { IsSuccess = false, Message = $"Erro interno de servidor: {ex.Message}" };
            }
        }

        public async Task<RegisterResult> RegisterAsync(RegisterUserDto register)
        {
            try
            {
                var userExists = await _userRepository.GetUserByEmailAsync(register.Email);

                if (userExists != null)
                {
                    return new RegisterResult
                    {
                        IsSuccess = false,
                        Message = "Usuário já existe com este email"
                    };
                }

                var user = new User
                {
                    Email = register.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(register.Password),
                    Role = register.Role
                };

                await _userRepository.AddAsync(user);

                return new RegisterResult { IsSuccess = true, Message = "Usuário criado com sucesso" };
            }
            catch (Exception ex)
            {
                return new RegisterResult { IsSuccess = false, Message = $"Erro interno de servidor: {ex.Message}" };
            }
            
        }
    }
}
