using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BeautyShopDataAccess.Entities;

[Table("User")]
public class UserEntity : IdentityUser<int>, IBaseEntity
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string HashPassword { get; set; }

    public virtual ICollection<CardEntity>? Cards { get; set; }
    public virtual ICollection<OrderEntity>? Orders { get; set; }
    public Guid ExternalId { get; set; }
    public DateTime ModificationTime { get; set; }
    public DateTime CreationTime { get; set; }
}

public class UserRole : IdentityRole<int>
{
}