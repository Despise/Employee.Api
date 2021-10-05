using AutoMapper;
using Employees.Application.Features.Employee.Commands;
using Employees.Domain.DTOs;
using Employees.Domain.Entities;

namespace Employees.Application.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, CreateEmployeeCommand>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeCommand>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}
