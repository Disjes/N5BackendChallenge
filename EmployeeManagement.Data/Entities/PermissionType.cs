using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Data.Entities;

public class PermissionType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int PermissionTypeId { get; set; }
    public string TypeName { get; set; }

    // Navigation property
    public virtual ICollection<Permission> Permissions { get; set; }
}