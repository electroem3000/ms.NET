using BeautyShop.Mapper;
using BeautyShopBL.Mapper;

namespace BeautyShop.Service.IoC;

public class MapperConfigurator
{
    public static void ConfigureServices(WebApplicationBuilder builder)
    {
        var services = builder.Services;
        services.AddAutoMapper(config =>
        {
            config.AddProfile<UsersBLProfile>();
            config.AddProfile<UsersServiceProfile>();
        });
    }
}