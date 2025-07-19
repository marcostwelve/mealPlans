using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Model;
using Repository.Repository.IRepository;

namespace Repository.Repository
{
    public class FoodRepository : IFoodRepository
    {
        private readonly ApplicationDBContext _context;

        public FoodRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task CreateFoodAsync(Food food)
        {
            await _context.Foods.AddAsync(food);
            await SaveFoodAsync();
        }

        public async Task DeleteFoodAsync(int id)
        {
            var food = await GetFoodByIdAsync(id);
            _context.Foods.Remove(food);
            await SaveFoodAsync();
        }

        public async Task<IEnumerable<Food>> GetAllFoodsAsync()
        {
            var foods = await _context.Foods.AsNoTracking().ToListAsync();
            return foods;
        }

        public async Task<Food> GetFoodByIdAsync(int id)
        {
            var food = await _context.Foods.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
            return food;
        }

        public async Task UpdateFoodAsync(Food food)
        {
            _context.Foods.Update(food);
            await SaveFoodAsync();
        }

        public async Task<bool> SaveFoodAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
