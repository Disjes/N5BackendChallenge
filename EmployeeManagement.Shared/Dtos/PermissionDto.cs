namespace EmployeeManagement.Shared.Dtos;

public class PermissionDto
{
    public int Id { get; set; } = 0;
    public string EmployeeForename { get; set; }
    public string EmployeeSurname { get; set; }
    public DateTime PermissionDate { get; set; }
    public int PermissionType { get; set; } = 0;
}