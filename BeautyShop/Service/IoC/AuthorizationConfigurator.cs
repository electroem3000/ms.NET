using BeautyShop.Settings;
using BeautyShopDataAccess;
using BeautyShopDataAccess.Entities;
using Duende.IdentityServer.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace BeautyShop.Service.IoC;

public class AuthorizationConfigurator
{
    public static void ConfigureServices(IServiceCollection services, BeautyShopSettings settings)
    {
        IdentityModelEventSource.ShowPII = true;
        services.AddIdentity<UserEntity, UserRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
            })
            .AddEntityFrameworkStores<BeautyShopDbContext>()
            .AddSignInManager()
            .AddDefaultTokenProviders();
        services.AddIdentityServer()
            .AddInMemoryApiScopes([new ApiScope("api")])
            .AddInMemoryClients([
                new Client
                {
                    ClientId = settings.ClientId!,
                    ClientName = settings.ClientId,
                    Enabled = true,
                    AllowOfflineAccess = true,
                    AllowedGrantTypes =
                    [
                        GrantType.ClientCredentials,
                        GrantType.ResourceOwnerPassword,
                    ],
                    ClientSecrets =
                    [
                        new Secret(settings.ClientSecret!.Sha256())
                    ],
                    AllowedScopes = ["api"]
                }
            ])
            .AddAspNetIdentity<UserEntity>();
        services.AddAuthentication(options =>
        {
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
        {
            options.RequireHttpsMetadata = false;
            options.Authority = settings.IdentityServerUri;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = false,
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireSignedTokens = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
            options.Audience = "api";
        });
        services.AddAuthorization();
    }
    public static void ConfigureApplication(IApplicationBuilder app)
    {
        app.UseIdentityServer();
        app.UseAuthentication();
        app.UseAuthorization();
    }
}