using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Data.Entities;

public class Permission
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PermissionId { get; set; }
    
    public string EmployeeName { get; set; }
    public string EmployeeLastName { get; set; }
    

    [ForeignKey("PermissionType")]
    public int PermissionTypeId { get; set; }

    public DateTime PermissionDate { get; set; }

    // Navigation properties
    public virtual PermissionType? PermissionType { get; set; }
}