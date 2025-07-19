using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Model.Dto.Patient
{
    public class CreatePatientDto
    {
        [Required]
        [StringLength(100, ErrorMessage = "O nome completo deve ter no máximo {1} caracteres.")]
        public string FullName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
