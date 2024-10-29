using BeautyShopDataAccess;
using Microsoft.EntityFrameworkCore;

namespace Service.loC;

public class DbContextConfigurator
{
    public static void ConfigureServices(WebApplicationBuilder builder)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false)
            .Build();
        var connectionString = configuration.GetValue<string>("BeautyShopContext");

        builder.Services.AddDbContextFactory<BeautyShopDbContext>(
            options => { options.UseNpgsql(connectionString); },
            ServiceLifetime.Scoped);
    }

    public static void ConfigureApplication(IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var contextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<BeautyShopDbContext>>();
        using var context = contextFactory.CreateDbContext();
        context.Database.Migrate();
    }
}