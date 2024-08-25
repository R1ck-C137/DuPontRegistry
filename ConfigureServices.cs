using DuPontRegistry.DataAccess;
using DuPontRegistry.DataAccess.Interface;
using DuPontRegistry.DataProcessor;
using DuPontRegistry.DataProcessor.Interface;
using DuPontRegistry.Service;
using DuPontRegistry.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace DuPontRegistry
{
    public class ConfigureServices
    {
        public static void SetDIConfig(IServiceCollection services)
        {
            
            services.AddSingleton<ICarDp, CarDp>();
            services.AddSingleton<ISellerDp, SellerDp>();
            services.AddSingleton<IBuyerDp, BuyerDp>();
            services.AddSingleton<ICarDp, CarDp>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddSingleton<IBuyer, BuyerService>();
            services.AddSingleton<ISeller, SellerService>();
            services.AddSingleton<IUser, UserService>();
        }
    }
}
