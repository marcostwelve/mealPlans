using AutoMapper;
using Repository.Model;
using Repository.Model.Dto.Auth.Dtos;
using Repository.Model.Dto.Food;
using Repository.Model.Dto.MealPlan;
using Repository.Model.Dto.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Mapper
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        {
            CreateMap<Patient, CreatePatientDto>().ReverseMap();
            CreateMap<Patient, UpdatePatientDto>().ReverseMap();
            CreateMap<Patient, ViewPatientDto>().ReverseMap();

            CreateMap<Food, CreateFoodDto>().ReverseMap();
            CreateMap<Food, FoodDto>().ReverseMap();
            CreateMap<Food, UpdateFoodDto>().ReverseMap();

            CreateMap<CreateMealPlanDto, MealPlan>();
            CreateMap<AddFoodToPlanDto, MealPlanItem>();

            CreateMap<MealPlanItem, MealPlanItemDto>()
                .ForMember(dest => dest.FoodName, opt => opt.MapFrom(src => src.Food.Name))
                .ForMember(dest => dest.Calories, opt => opt.MapFrom(src => (src.Food.CaloriesPer100g / 100) * src.Quantity));

            CreateMap<MealPlan, MealPlanDto>()
                .ForMember(dest => dest.MealPlanItems, opt => opt.MapFrom(src => src.MealPlanItems));
        }
    }
}
