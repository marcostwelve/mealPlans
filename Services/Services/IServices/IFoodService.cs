using Repository.Model;
using Repository.Model.Dto.Food;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services.IServices
{
    public interface IFoodService
    {
        Task<IEnumerable<FoodDto>> GetAllFoodsAsync();
        Task<FoodDto> GetFoodByIdAsync(int id);
        Task<UpdateFoodDto> CreateFoodAsync(CreateFoodDto food);
        Task UpdateFoodAsync(UpdateFoodDto food);
        Task DeleteFoodAsync(int id);
    }
}
