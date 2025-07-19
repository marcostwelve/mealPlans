using Repository.Model;
using Repository.Model.Dto.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.IServices
{
    public interface IPatientService
    {
        Task<ViewPatientDto> GetPatientByIdAsync(int id);
        Task<IEnumerable<ViewPatientDto>> GetAllPatientsAsync();
        Task<ViewPatientDto> CreatePatientAsync(CreatePatientDto entity);
        Task UpdatePatientAsync(UpdatePatientDto entity);
        Task RemovePatientAsync(int id);
    }
}
