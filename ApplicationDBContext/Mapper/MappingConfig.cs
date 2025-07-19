using AutoMapper;
using Repository.Model;
using Repository.Model.Dto.Auth.Dtos;
using Repository.Model.Dto.Food;
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
        }
    }
}
