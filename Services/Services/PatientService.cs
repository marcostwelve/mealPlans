using AutoMapper;
using Repository.Model;
using Repository.Model.Dto.Patient;
using Repository.Repository.IRepository;
using Services.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class PatientService : IPatientService
    {
        private readonly IMapper _mapper;
        private readonly IPatientRepository _patientRepository;
        public PatientService(IMapper mapper, IPatientRepository patientRepository)
        {
            _mapper = mapper;
            _patientRepository = patientRepository;
        }
        public async Task<ViewPatientDto> CreatePatientAsync(CreatePatientDto entity)
        {
            try
            {
                var patientEntity = _mapper.Map<Patient>(entity);

                await _patientRepository.CreatePatientAsync(patientEntity);

                return _mapper.Map<ViewPatientDto>(patientEntity);
            }
            catch (Exception ex)
            {
                
                throw new Exception($"Erro ocorreu ao criar paciente: {ex.Message}");
            }
            
        }

        public async Task<IEnumerable<ViewPatientDto>> GetAllPatientsAsync()
        {
            try
            {
                var patients = await _patientRepository.GetAllPatientsAsync();
                var patientsDto = _mapper.Map<IEnumerable<ViewPatientDto>>(patients);
                return patientsDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ocorreu ao obter todos os pacientes: {ex.Message}");
            }
        }

        public async Task<ViewPatientDto> GetPatientByIdAsync(int id)
        {
            try
            {
                var patient = await _patientRepository.GetPatientByIdAsync(id);
                var patientDto = _mapper.Map<ViewPatientDto>(patient);
                return patientDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ocorreu ao obter paciente com ID {id}: {ex.Message}");
            }
        }

        public async Task RemovePatientAsync(int id)
        {
            try
            {
                var patient = await _patientRepository.GetPatientByIdAsync(id);
                if (patient == null)
                {
                    throw new Exception($"Paciente com ID {id} não encontrado.");
                }
                await _patientRepository.RemovePatientAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ocorreu ao remover paciente com ID {id}: {ex.Message}");
            }
        }

        public async Task UpdatePatientAsync(UpdatePatientDto entity)
        {
            try
            {
                var patientEntity = _mapper.Map<Patient>(entity);
                await _patientRepository.UpdatePatientAsync(patientEntity);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ocorreu ao atualizar paciente: {ex.Message}");
            }
        }
    }
}
