using BeautyShopBL.Users.Entity;

namespace BeautyShopBL.Users.Provider;

public interface IUsersProvider
{
    IEnumerable<UserModel> GetUsers(UserFilterModel filter = null);
    UserModel GerUserInfo(int id);
}