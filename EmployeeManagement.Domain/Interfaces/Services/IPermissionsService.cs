using EmployeeManagement.Shared.Dtos;

namespace EmployeeManagement.Domain.Interfaces.Services;

public interface IPermissionsService
{
    Task<PermissionDto> AddPermissionToUser(PermissionDto permissionDto);
    Task<bool> ModifyPermission(PermissionDto? permission);
    Task<List<PermissionDto>> GetPermissions();
}