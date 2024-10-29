namespace BeautyShopDataAccess.Entities;

public class OrderProductEntity : BaseEntity
{
    public int OrderId { get; set; }
    public virtual OrderEntity Order { get; set; }

    public int ProductId { get; set; }
    public virtual ProductEntity Product { get; set; }
}