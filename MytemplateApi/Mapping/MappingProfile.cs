using AutoMapper;
using MytemplateApi.DTOs;
using MytemplateApi.Models;
using MytemplateApi.Repositories;

namespace MytemplateApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() { 
            CreateMap<Employee,GetEmployeeDto>().ReverseMap();  
            CreateMap<CreateEmployeeDto,Employee>().ReverseMap();  
            CreateMap<Department,GetDepartmentDto>().ReverseMap();  
            CreateMap<CreateDepartmentDto,Department>().ReverseMap();  
        }
    }
}
