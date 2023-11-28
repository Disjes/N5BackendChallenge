namespace EmployeeManagement.Shared.Dtos;

public class PermissionDto
{
    public int PermissionId { get; set; } = 0;
    public string EmployeeName { get; set; }
    public string EmployeeLastName { get; set; }
    public DateTime PermissionDate { get; set; }
    public int PermissionTypeId { get; set; } = 0;
}