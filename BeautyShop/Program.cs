using BeautyShop.DI;
using BeautyShop.Service.IoC;
using Service.loC;

var builder = WebApplication.CreateBuilder(args);
ApplicationConfigurator.ConfigureServices(builder);

var app = builder.Build();

ApplicationConfigurator.ConfigureApplication(app);
app.Run();