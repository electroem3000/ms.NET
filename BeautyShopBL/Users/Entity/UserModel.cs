namespace BeautyShopBL.Users.Entity;

public class UserModel
{
    public int Id { get; set; }
    public Guid ExternalId { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime ModificationTime { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Role { get; set; }
}