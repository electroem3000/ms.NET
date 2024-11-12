namespace BeautyShopBL.Users.Entity;

public class UserFilterModel
{
    public string? UsernamePart { get; set; }
    public string? EmailPart { get; set; }
    public DateTime? CreationTime { get; set; }
    public DateTime? ModificationTime { get; set; }
    public string? Role { get; set; }
}