using Repository.Helpers.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model.Dto.Auth.Dtos
{
    public class RegisterUserDto
    {
        [Required]
        [EmailAddress (ErrorMessage = "O email informado não é válido")]
        public string Email { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "O tamanho mínimo da senha é {0}")]
        public string Password { get; set; }
        public RoleUser Role { get; set; }
    }
}
