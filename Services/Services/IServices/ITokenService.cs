using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Model.Dto.Auth.Dtos;

namespace Services.Services.IServices
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
