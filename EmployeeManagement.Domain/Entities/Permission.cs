namespace EmployeeManagement.Domain.Entities;

public class Permission
{
    public int Id { get; set; } = 0;
    
    public string EmployeeForename { get; set; }
    public string EmployeeSurname { get; set; }
    public int PermissionTypeId { get; set; } = 0;
    public DateTime PermissionDate { get; set; }
}