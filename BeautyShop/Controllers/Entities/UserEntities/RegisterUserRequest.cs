using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace BeautyShop.Controllers.Entities.UserEntities;

public class RegisterUserRequest
{
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    
    public string Role { get; set; }
}