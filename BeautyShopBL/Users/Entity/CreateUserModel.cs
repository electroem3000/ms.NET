namespace BeautyShopBL.Users.Entity;

public class CreateUserModel
{
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public string Username { get; set; }
    public string Role { get; set; }
}