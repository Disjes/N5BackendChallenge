namespace EmployeeManagement.Services.Models;

public class OperationType
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = String.Empty;
}