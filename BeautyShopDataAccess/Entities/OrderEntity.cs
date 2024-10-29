using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyShopDataAccess.Entities;

[Table("OrderEntity")]
public class OrderEntity : BaseEntity
{
    public int Cost { get; set; }
    private DateTime CreationDate { get; set; }
    public int Weight { get; set; }
    private DateTime StorageLife { get; set; }

    public int UserId { get; set; }
    public virtual UserEntity User { get; set; }
    public virtual ICollection<OrderProductEntity>? OrderProducts { get; set; }
}