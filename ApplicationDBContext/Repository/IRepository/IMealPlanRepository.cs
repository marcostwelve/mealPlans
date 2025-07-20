using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.IRepository
{
    public interface IMealPlanRepository
    {
        Task AddMealPlanAsync(MealPlan mealPlan);

        Task<MealPlan> GetMealPlanByIdAsync(int id);

        Task AddItemToPlanAsync(MealPlanItem mealPlanItem);

        Task<MealPlan> GetByPatientAndDateAsync(int patientId, DateTime date);

        Task<bool> SaveMealPlansAsync();
    }
}
