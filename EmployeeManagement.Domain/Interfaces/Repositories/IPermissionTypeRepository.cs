using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Domain.Interfaces.Repositories;

public interface IPermissionTypeRepository
{
    IEnumerable<PermissionType> GetAllPermissionTypes();
    PermissionType GetPermissionTypeById(int id);
    void AddPermissionType(PermissionType employee);
    void UpdatePermissionType(PermissionType employee);
    void DeletePermissionType(int id);
}