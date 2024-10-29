using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyShopDataAccess.Entities;

[Table("User")]
public class UserEntity : BaseEntity
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string HashPassword { get; set; }
    public string Role { get; set; }

    public virtual ICollection<CardEntity>? Cards { get; set; }
    public virtual ICollection<OrderEntity>? Orders { get; set; }
}