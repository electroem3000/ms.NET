using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyShopDataAccess.Entities;

[Table("ProductEntity")]
public class ProductEntity : BaseEntity
{
    public int Cost { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public int Volume { get; set; }
    public int Weight { get; set; }

    public virtual ICollection<OrderProductEntity>? OrderProducts { get; set; }
}