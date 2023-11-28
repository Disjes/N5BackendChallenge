namespace EmployeeManagement.Domain.Entities;

public class Permission
{
    public int PermissionId { get; set; } = 0;
    
    public string EmployeeName { get; set; }
    public string EmployeeLastName { get; set; }
    public int PermissionTypeId { get; set; } = 0;
    public DateTime PermissionDate { get; set; }
}