using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Repository.Context;
using Repository.Model;
using Repository.Model.Dto.Patient;
using Repository.Repository.IRepository;

namespace Repository.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public PatientRepository(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreatePatientAsync(Patient entity)
        {
            await _dbContext.Patients.AddAsync(entity);
            await SavePatientAsync();
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync(Pagination pagination)
        {
            var patients = await _dbContext.Patients.Where(p => p.IsActive)
                .OrderBy(p => p.FullName)
                .Skip((pagination.PageNumber - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .ToListAsync();

            return patients;
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            var patient = await _dbContext.Patients.FirstOrDefaultAsync(p => p.Id == id && p.IsActive);
            return patient;
        }

        public async Task RemovePatientAsync(int id)
        {
            var patient =  await GetPatientByIdAsync(id);
            patient.IsActive = false;
            await UpdatePatientAsync(patient);
             
            await SavePatientAsync();
        }

        public async Task<bool> SavePatientAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task UpdatePatientAsync(Patient entity)
        {
            _dbContext.Patients.Update(entity);
            await SavePatientAsync();
        }
    }
}
