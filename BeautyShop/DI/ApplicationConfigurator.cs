using BeautyShop.Service.IoC;
using BeautyShop.Settings;
using Service.loC;

namespace BeautyShop.DI;

public static class ApplicationConfigurator
{
    public static void ConfigureServices(WebApplicationBuilder builder, BeautyShopSettings beautyShopSettings)
    {
        DbContextConfigurator.ConfigureServices(builder);
        SerilogConfigurator.ConfigureService(builder);
        SwaggerConfigurator.ConfigureServices(builder.Services);
        MapperConfigurator.ConfigureServices(builder);

        ServicesConfigurator.ConfigureServices(builder.Services, beautyShopSettings);
        AuthorizationConfigurator.ConfigureServices(builder.Services, beautyShopSettings);
        
        builder.Services.AddControllers();
    }
    public static void ConfigureApplication(WebApplication app)
    {
        SerilogConfigurator.ConfigureApplication(app);
        SwaggerConfigurator.ConfigureApplication(app);
        DbContextConfigurator.ConfigureApplication(app);
        AuthorizationConfigurator.ConfigureApplication(app);
        
        app.UseHttpsRedirection();
        app.MapControllers();
    }
}