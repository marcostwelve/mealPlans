using Repository.Model.Dto;
using Repository.Model.Dto.Auth.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.IServices
{
    public interface IAuthService
    {
        Task<LoginResult> LoginAsync(LoginDto login);

        Task<RegisterResult> RegisterAsync(RegisterUserDto register);
    }
}
