using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Data.Entities;

public class Permission
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    public string EmployeeForename { get; set; }
    public string EmployeeSurname { get; set; }
    
    [ForeignKey("PermissionType")]
    public int PermissionType { get; set; }

    public DateTime PermissionDate { get; set; }

    // Navigation properties
    public virtual PermissionType? PermissionTypeNavigation { get; set; }
}