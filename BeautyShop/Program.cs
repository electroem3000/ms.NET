using BeautyShop.DI;
using BeautyShop.Service.IoC;
using BeautyShop.Settings;
using Service.loC;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();
var settings = BeautyShopSettingsReader.Read(configuration);

var builder = WebApplication.CreateBuilder(args);


ApplicationConfigurator.ConfigureServices(builder, settings);

var app = builder.Build();
