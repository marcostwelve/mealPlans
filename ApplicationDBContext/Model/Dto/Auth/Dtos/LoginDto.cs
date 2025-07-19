using Repository.Helpers.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model.Dto.Auth.Dtos
{
    public class LoginDto
    {
        [Required]
        [EmailAddress(ErrorMessage = "O email informado não é válido")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
