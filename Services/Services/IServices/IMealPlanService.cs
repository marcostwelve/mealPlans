using Repository.Model.Dto.MealPlan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.IServices
{
    public interface IMealPlanService
    {
        Task<MealPlanDto> CreateMealPlanAsync(CreateMealPlanDto createDto);
        Task<MealPlanDto> GetMealPlanByIdAsync(int id);
        Task<MealPlanDto> GetTodaysMealPlanByPatientIdAsync(int id);
        Task<MealPlanDto> AddFoodToMealPlanAsync(int id, AddFoodToPlanDto foodDto);
    }
}
