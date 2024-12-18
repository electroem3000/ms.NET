using BeautyShop.Settings;
using Microsoft.Extensions.Configuration;

namespace BeautyShopUnitTests;

public class TestConfigurator
{
    private static IConfiguration GetConfiguration()
    {
        return new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();
    }
    public static BeautyShopSettings GetSettings()
    {
        return BeautyShopSettingsReader.Read(GetConfiguration());
    }
}