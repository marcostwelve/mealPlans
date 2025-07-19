using Repository.Model;
using Repository.Model.Dto.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.IRepository
{
    public interface IPatientRepository
    {
        Task<Patient> GetPatientByIdAsync(int id);
        Task<IEnumerable<Patient>> GetAllPatientsAsync();
        Task CreatePatientAsync(Patient entity);
        Task UpdatePatientAsync(Patient entity);
        Task RemovePatientAsync(int id);
        Task<bool> SavePatientAsync();
    }
}
