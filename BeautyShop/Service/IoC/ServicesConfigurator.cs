using AutoMapper;
using BeautyShopBL.Users.Manager;
using BeautyShopBL.Users.Provider;
using BeautyShopDataAccess;
using BeautyShopDataAccess.Entities;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

namespace BeautyShop.Service.IoC;

public static class ServicesConfigurator
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IRepository<UserEntity>>(x => 
            new Repository<UserEntity>(x.GetRequiredService<IDbContextFactory<BeautyShopDbContext>>()));
        services.AddScoped<IUsersProvider>(x => 
            new UsersProvider(x.GetRequiredService<IRepository<UserEntity>>(), 
                x.GetRequiredService<IMapper>()));
        services.AddScoped<IUsersManager>(x =>
            new UsersManager(x.GetRequiredService<IRepository<UserEntity>>(),
                x.GetRequiredService<IMapper>()));
    }
}