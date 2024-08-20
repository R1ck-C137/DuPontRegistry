using DuPontRegistry.DataAccess;
using DuPontRegistry.DataAccess.Interface;
using DuPontRegistry.DataProces;
using DuPontRegistry.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace DuPontRegistry
{
    public class ConfigureServices
    {
        public static void SetDIConfig(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSingleton<ICarDp, CarDp>();
            services.AddScoped<ISellerDp, SellerDp>();
            services.AddScoped<IBuyerDp, BuyerDp>();
            services.AddScoped<ICarDp, CarDp>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<IBuyer, BuyerService>();
            services.AddScoped<ISeller, SellerService>();
        }
    }
}
