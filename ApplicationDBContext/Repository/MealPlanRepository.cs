using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Model;
using Repository.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class MealPlanRepository : IMealPlanRepository
    {
        private readonly ApplicationDBContext _context;
        public MealPlanRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task AddItemToPlanAsync(MealPlanItem mealPlanItem)
        {
            await _context.MealPlanItems.AddAsync(mealPlanItem);
            await SaveMealPlansAsync();
        }

        public async Task AddMealPlanAsync(MealPlan mealPlan)
        {
            await _context.MealPlans.AddAsync(mealPlan);
            await SaveMealPlansAsync();
        }

        public async Task<MealPlan> GetByPatientAndDateAsync(int patientId, DateTime date)
        {
            return await _context.MealPlans
                .Include(mp => mp.MealPlanItems)
                .ThenInclude(mpi => mpi.Food)
                .FirstOrDefaultAsync(mp => mp.PatientId == patientId && mp.PlanDate.Date == date.Date);
        }

        public async Task<MealPlan> GetMealPlanByIdAsync(int id)
        {
            return await _context.MealPlans
                .Include(mp => mp.MealPlanItems)
                .ThenInclude(mpi => mpi.Food)
                .FirstOrDefaultAsync(mp => mp.Id == id);
        }

        public async Task<bool> SaveMealPlansAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
