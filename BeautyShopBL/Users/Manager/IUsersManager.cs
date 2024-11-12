using BeautyShopBL.Users.Entity;

namespace BeautyShopBL.Users.Manager;

public interface IUsersManager
{
    UserModel CreateUser(CreateUserModel createModel);
    void DeleteUser(int id);
    UserModel UpdateUser(UpdateUserModel updateModel);
}