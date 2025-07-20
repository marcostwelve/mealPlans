using AutoMapper;
using Moq;
using Repository.Model;
using Repository.Model.Dto.Patient;
using Repository.Repository.IRepository;
using Services.Services;
using System.Threading.Tasks;
using Xunit;

namespace mealPlansAPI.Tests
{
    public class PatientServiceTests
    {
        private readonly Mock<IPatientRepository> _mockPatientRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly PatientService _service;

        public PatientServiceTests()
        {
            _mockPatientRepository = new Mock<IPatientRepository>();
            _mockMapper = new Mock<IMapper>();
            _service = new PatientService(_mockPatientRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task GetPatientByIdAsync_ShouldReturnPatientDto_WhenPatientExists()
        {
            var patientId = 1;
            var patient = new Patient { Id = patientId, FullName = "Paciente Teste", IsActive = true };
            var patientDto = new ViewPatientDto { Id = patientId, FullName = "Paciente Teste" };

            _mockPatientRepository.Setup(repo => repo.GetPatientByIdAsync(patientId))
                .ReturnsAsync(patient);

            _mockMapper.Setup(mapper => mapper.Map<ViewPatientDto>(patient))
                .Returns(patientDto);

            var result = await _service.GetPatientByIdAsync(patientId);

            Assert.NotNull(result);
            Assert.IsType<ViewPatientDto>(result);
            Assert.Equal(patientId, result.Id);
            Assert.Equal("Paciente Teste", result.FullName);
        }

        [Fact]
        public async Task GetPatientByIdAsync_ShouldReturnNull_WhenPatientDoesNotExist()
        {
            var patientId = 99;

            _mockPatientRepository.Setup(repo => repo.GetPatientByIdAsync(patientId))
                .ReturnsAsync((Patient?)null);

            var result = await _service.GetPatientByIdAsync(patientId);

            Assert.Null(result);
        }

        [Fact]
        public async Task CreatePatientAsync_ShoudCallAddSaveChanges_WhenCalled()
        {
            
            var createDto = new CreatePatientDto { FullName = "Novo Paciente", DateOfBirth = new System.DateTime(1990, 1, 1) };
            var patient = new Patient { Id = 1, FullName = createDto.FullName, DateOfBirth = createDto.DateOfBirth };
            var patientDto = new ViewPatientDto { Id = 1, FullName = patient.FullName, DateOfBirth = patient.DateOfBirth };

  
            _mockMapper.Setup(m => m.Map<Patient>(createDto)).Returns(patient);
            _mockMapper.Setup(m => m.Map<ViewPatientDto>(patient)).Returns(patientDto);

            var result = await _service.CreatePatientAsync(createDto);

            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            
            _mockPatientRepository.Verify(r => r.CreatePatientAsync(It.IsAny<Patient>()), Times.Once);
        }

        [Fact]
        public async Task ShouldReturnTrue_WhenDeletionIsSuccessful()
        {

            var createDto = new CreatePatientDto { FullName = "Novo Paciente", DateOfBirth = new System.DateTime(1990, 1, 1) };
            var patient = new Patient { Id = 1, FullName = createDto.FullName, DateOfBirth = createDto.DateOfBirth };

            _mockMapper.Setup(m => m.Map<Patient>(createDto)).Returns(patient);

            _mockPatientRepository.Setup(r => r.GetPatientByIdAsync(patient.Id))
                                .ReturnsAsync((Patient?)null);

            _mockPatientRepository.Setup(r => r.RemovePatientAsync(patient.Id));

            await Assert.ThrowsAsync<Exception>(() => _service.RemovePatientAsync(patient.Id));
        }

        [Fact]
        public async Task RemovePatientAsync_ShouldThrowException_WhenPatientDoesNotExist()
        {
            var patientId = 99;
            _mockPatientRepository.Setup(r => r.GetPatientByIdAsync(patientId))
                                .ReturnsAsync((Patient?)null);

            await Assert.ThrowsAsync<Exception>(() => _service.RemovePatientAsync(patientId));
        }
    }
}
