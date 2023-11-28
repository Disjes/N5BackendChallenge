using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Domain.Interfaces.Repositories;

public interface IPermissionRepository
{
    IEnumerable<Permission> GetAllPermissions();
    Permission GetPermissionById(int id);
    void AddPermission(Permission employee);
    void UpdatePermission(Permission employee);
    void DeletePermission(int id);
}