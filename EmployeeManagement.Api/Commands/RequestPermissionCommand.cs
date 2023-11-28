using EmployeeManagement.Shared.Dtos;
using MediatR;

namespace EmployeeManagement.Api.Commands;

public class RequestPermissionCommand: IRequest<PermissionDto>
{
    public string EmployeeName { get; set; } = String.Empty;
    public string EmployeeLastName { get; set; } = String.Empty;
    public DateTime PermissionDate { get; set; } = DateTime.UtcNow;
    public int PermissionTypeId { get; set; } = 0;

    public RequestPermissionCommand(
        int permissionTypeId, 
        string employeeName, 
        string employeeLastName,
        DateTime permissionDate)
    {
        PermissionTypeId = permissionTypeId;
        EmployeeName = employeeName;
        EmployeeLastName = employeeLastName;
        PermissionDate = permissionDate;
    }
}