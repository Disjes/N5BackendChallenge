using AutoMapper;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Shared.Dtos;

namespace EmployeeManagement.Services;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Employee, EmployeeDto>().ReverseMap();
        CreateMap<Permission, PermissionDto>().ReverseMap();
        CreateMap<PermissionType, PermissionTypeDto>().ReverseMap();
    }
}