using System.ComponentModel.DataAnnotations.Schema;

namespace BeautyShopDataAccess.Entities;

[Table("CardEntity")]
public class CardEntity : BaseEntity
{
    public int CVC { get; set; }
    public string CardNumber { get; set; }
    public DateTime EndDate { get; set; }

    public int UserId { get; set; }
    public virtual UserEntity User { get; set; }
}