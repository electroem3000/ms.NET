namespace BeautyShop.Settings;

public static class BeautyShopSettingsReader
{
    public static BeautyShopSettings Read(IConfiguration configuration)
    {
        return new BeautyShopSettings
        {
            BeautyShopContextConnectionString = configuration.GetValue<string>("BeautyShopContext"),
            ClientId = configuration.GetValue<string>("IdentityServerSettings:ClientId"),
            ClientSecret = configuration.GetValue<string>("IdentityServerSettings:ClientSecret"),
            IdentityServerUri = configuration.GetValue<string>("IdentityServerSettings:Uri")
        };
    }
}