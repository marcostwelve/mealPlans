using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository.IRepository
{
    public interface IFoodRepository
    {
        Task<IEnumerable<Food>> GetAllFoodsAsync(Pagination pagination);
        Task<Food> GetFoodByIdAsync(int id);
        Task CreateFoodAsync(Food food);
        Task UpdateFoodAsync(Food food);
        Task DeleteFoodAsync(int id);
        Task<bool> SaveFoodAsync();
    }
}
