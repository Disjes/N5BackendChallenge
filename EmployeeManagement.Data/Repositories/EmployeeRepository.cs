using AutoMapper;
using EmployeeManagement.Data.Context;
using EmployeeManagement.Domain.Entities;
using EmployeeManagement.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly EmployeesContext _context;
    private readonly IMapper _mapper; 

    public EmployeeRepository(EmployeesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Employee> GetAllEmployees()
    {
        return _mapper.Map<List<Employee>>(_context.Employee.ToList());
    }

    public Employee GetEmployeeById(int id)
    {
        return _mapper.Map<Employee>(_context.Employee
            .FirstOrDefault(e => e.EmployeeId == id));
    }

    public void AddEmployee(Employee employee)
    {
        var efEmployee = _mapper.Map<Data.Entities.Employee>(employee);
        _context.Employee.Add(efEmployee);
    }

    public void UpdateEmployee(Employee employee)
    {
        var efEmployee = _mapper.Map<Data.Entities.Employee>(employee);
        _context.Entry(efEmployee).State = EntityState.Modified;
    }

    public void DeleteEmployee(int id)
    {
        var employee = _context.Employee.Find(id);
        if (employee != null)
        {
            _context.Employee.Remove(employee);
        }
    }
}