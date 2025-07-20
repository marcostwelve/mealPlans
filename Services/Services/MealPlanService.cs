using AutoMapper;
using Repository.Model;
using Repository.Model.Dto.MealPlan;
using Repository.Repository.IRepository;
using Services.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class MealPlanService : IMealPlanService
    {
        private readonly IMealPlanRepository _mealPlanRepository;
        private readonly IPatientRepository _patientRepository;
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;
        public MealPlanService(
            IMealPlanRepository mealPlanRepository,
            IPatientRepository patientRepository,
            IFoodRepository foodRepository,
            IMapper mapper)
        {
            _mealPlanRepository = mealPlanRepository;
            _patientRepository = patientRepository;
            _foodRepository = foodRepository;
            _mapper = mapper;
        }
        public async Task<MealPlanDto> AddFoodToMealPlanAsync(int id, AddFoodToPlanDto foodDto)
        {
            try
            {
                var plan = await _mealPlanRepository.GetMealPlanByIdAsync(id);
                var food = await _foodRepository.GetFoodByIdAsync(foodDto.FoodId);
                if (plan == null || food == null)
                {
                    throw new ArgumentException("Plano ou alimento não encontrado");
                }

                var newItem = _mapper.Map<MealPlanItem>(foodDto);
                newItem.MealPlanId = id;

                await _mealPlanRepository.AddItemToPlanAsync(newItem);

                return await GetMealPlanByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao adicionar alimento ao plano de refeição: {ex.Message}", ex);
            }
        }

        public async Task<MealPlanDto> CreateMealPlanAsync(CreateMealPlanDto createDto)
        {
            try
            {
                var patient = _patientRepository.GetPatientByIdAsync(createDto.PatientId);
                if (patient == null)
                {
                    throw new ArgumentException("Paciente não encontrado");
                }

                var mealPlanEntity = _mapper.Map<MealPlan>(createDto);
                await _mealPlanRepository.AddMealPlanAsync(mealPlanEntity);
                
                var mealPlanDto = _mapper.Map<MealPlanDto>(mealPlanEntity);
                return mealPlanDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao criar plano de refeição: {ex.Message}", ex);
            }

        }

        public async Task<MealPlanDto> GetMealPlanByIdAsync(int id)
        {
            try
            {
                var planEntity = await _mealPlanRepository.GetMealPlanByIdAsync(id);
                if (planEntity == null)
                {
                    throw new ArgumentException("Plano de refeição não encontrado");
                }

                var mealPlanDto = _mapper.Map<MealPlanDto>(planEntity);

                mealPlanDto.TotalCalories = CalculateTotalCalories(planEntity);

                return mealPlanDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter plano de refeição por ID: {ex.Message}", ex);
            }
        }

        public async Task<MealPlanDto> GetTodaysMealPlanByPatientIdAsync(int id)
        {
            try
            {
                var planEntity = await _mealPlanRepository.GetByPatientAndDateAsync(id, DateTime.UtcNow);

                if (planEntity == null)
                {
                    throw new ArgumentException("Plano de refeição do dia não encontrado para o paciente");
                }

                var mealPlanDto = _mapper.Map<MealPlanDto>(planEntity);

                mealPlanDto.TotalCalories = CalculateTotalCalories(planEntity);

                return mealPlanDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter plano de refeição do dia para o paciente: {ex.Message}", ex);
            }
        }

        private double CalculateTotalCalories(MealPlan plan)
        {
            if (plan.MealPlanItems == null || !plan.MealPlanItems.Any())
            {
                return 0;
            }

            double totalCalories = 0;

            foreach(var item in plan.MealPlanItems)
            {
                if (item.Unit.Equals("g", StringComparison.OrdinalIgnoreCase))
                {
                    totalCalories+= (item.Food.CaloriesPer100g / 100) * item.Quantity;
                }
            }
            return Math.Round(totalCalories, 2);
        }
    }
}
