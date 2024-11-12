using AutoMapper;
using BeautyShop.Controllers.Entities.UserEntities;
using BeautyShopBL.Users.Entity;

namespace BeautyShop.Mapper;

public class UsersServiceProfile : Profile
{
    public UsersServiceProfile()
    {
        CreateMap<UserFilter, UserFilterModel>();
        CreateMap<RegisterUserRequest, CreateUserModel>();
    }
}