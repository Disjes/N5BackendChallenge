using EmployeeManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data.Context;

public class EmployeesContext : DbContext
{
    public DbSet<Employee> Employee { get; set; }
    public DbSet<Permission> Permission { get; set; }
    public DbSet<PermissionType> PermissionType { get; set; }
    
    public EmployeesContext(DbContextOptions<EmployeesContext> options)
        : base(options)
    { }
}