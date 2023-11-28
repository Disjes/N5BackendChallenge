using EmployeeManagement.Domain.Entities;

namespace EmployeeManagement.Domain.Interfaces.Repositories;

public interface IEmployeeRepository
{
    IEnumerable<Employee> GetAllEmployees();
    Employee GetEmployeeById(int id);
    void AddEmployee(Employee employee);
    void UpdateEmployee(Employee employee);
    void DeleteEmployee(int id);
}