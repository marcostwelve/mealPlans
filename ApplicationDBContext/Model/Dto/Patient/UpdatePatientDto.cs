using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model.Dto.Patient
{
    public class UpdatePatientDto
    {
        [Required]
        [StringLength(100, ErrorMessage = "O nome completo deve ter no máximo {1} caracteres.")]
        public string FullName { get; set; }
        public bool IsActive { get; set; }

        // Como regra, não pode ser alterada a data de nascimento de um paciente
    }
}
