using AutoMapper;
using Repository.Model;
using Repository.Model.Dto.Food;
using Repository.Repository.IRepository;
using Services.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IMapper _mapper;
        public FoodService(IFoodRepository foodRepository, IMapper mapper)
        {
            _foodRepository = foodRepository;
            _mapper = mapper;
        }
        public async Task<UpdateFoodDto> CreateFoodAsync(CreateFoodDto food)
        {
            try
            {
                var foodEntity = _mapper.Map<Food>(food);
                await _foodRepository.CreateFoodAsync(foodEntity);
                var foodView = _mapper.Map<UpdateFoodDto>(foodEntity);
                return foodView;
            }
            catch (Exception ex)
            {
                throw new Exception($": {ex.Message}");
            }
        }

        public async Task DeleteFoodAsync(int id)
        {
            try
            {
                var food = await _foodRepository.GetFoodByIdAsync(id);
                await _foodRepository.DeleteFoodAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ocorreu ao deletar alimento com ID: {id}: {ex.Message}");
            }
        }

        public async Task<IEnumerable<FoodDto>> GetAllFoodsAsync(Pagination pagination)
        {
            try
            {
                var foods = await _foodRepository.GetAllFoodsAsync(pagination);
                var foodDtos = _mapper.Map<IEnumerable<FoodDto>>(foods);

                return foodDtos;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter todos os alimentos: {ex.Message}");
            }
        }

        public async Task<FoodDto> GetFoodByIdAsync(int id)
        {
            try
            {
                var food = await _foodRepository.GetFoodByIdAsync(id);
                var foodDto = _mapper.Map<FoodDto>(food);

                return foodDto;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter alimento com ID: {id}: {ex.Message}");
            }
        }

        public Task UpdateFoodAsync(UpdateFoodDto food)
        {
            try
            {
                var foodEntity = _mapper.Map<Food>(food);
                return _foodRepository.UpdateFoodAsync(foodEntity);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar alimento: {ex.Message}");
            }
        }
    }
}
