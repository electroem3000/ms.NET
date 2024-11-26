using BeautyShopBL.Authorization.Entities;
using BeautyShopBL.Users.Entity;

namespace BeautyShopBL.Authorization;

public interface IAuthProvider
{
    Task<UserModel> RegisterUser(string email, string password);
    Task<TokensResponse> AuthorizeUser(string email, string password);
}