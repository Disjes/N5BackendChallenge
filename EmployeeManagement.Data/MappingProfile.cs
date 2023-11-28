using AutoMapper;
using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Data;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Permission, Entities.Permission>().ReverseMap();
        CreateMap<PermissionType, Entities.PermissionType>().ReverseMap();
    }
}