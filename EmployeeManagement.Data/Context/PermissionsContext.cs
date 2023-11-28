using EmployeeManagement.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Data.Context;

public class PermissionsContext : DbContext
{
    public DbSet<Permission> Permission { get; set; }
    public DbSet<PermissionType> PermissionType { get; set; }
    
    public PermissionsContext(DbContextOptions<PermissionsContext> options)
        : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Permission>()
            .HasOne(s => s.PermissionTypeNavigation)
            .WithMany(b => b.Permissions)
            .HasForeignKey(s => s.PermissionType)
            .OnDelete(DeleteBehavior.Cascade);
    }
}