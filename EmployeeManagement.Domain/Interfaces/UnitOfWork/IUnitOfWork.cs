using EmployeeManagement.Domain.Interfaces.Repositories;

namespace EmployeeManagement.Domain.Interfaces.UnitOfWork;

public interface IUnitOfWork
{
    IPermissionTypeRepository PermissionTypes { get; }
    IPermissionRepository Permissions { get; }

    int Save(); // Commit changes
}