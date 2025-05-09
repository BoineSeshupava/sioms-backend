using SIOMS.Domain.Entities;
using System.ComponentModel.DataAnnotations;

public class Role
{
    [Key]
    public Guid RoleId { get; set; } = Guid.NewGuid();

    [Required]
    public string RoleName { get; set; }

    public ICollection<Customer> Customers { get; set; }
}
