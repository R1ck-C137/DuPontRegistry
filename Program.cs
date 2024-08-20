
using DuPontRegistry.DataAccess;
using DuPontRegistry.Models;
using DuPontRegistry.Services;
using NLog.Extensions.Logging;
using Microsoft.AspNetCore.HttpOverrides;
using Newtonsoft;
using Microsoft.OpenApi.Models;

namespace DuPontRegistry
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try 
            { 
                var builder = WebApplication.CreateBuilder(args);
                builder.Logging.ClearProviders();
                builder.Logging.AddNLog();

                builder.Services.AddControllers(); 
                builder.Services.AddControllers()
                    .AddNewtonsoftJson();

                ConfigureServices.SetDIConfig(builder.Services);
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
                
                var app = builder.Build();

                if (true)//app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }

                app.UseHttpsRedirection();

                app.UseAuthorization();

                app.MapControllers();

                app.Run();

                NLog.LogManager.GetCurrentClassLogger().Info("App started");
            }
            catch (Exception exception)
            {
                NLog.LogManager.GetCurrentClassLogger().Error(exception, "Stopped program because of exception");
                throw;
            }
            finally
            {
                NLog.LogManager.Shutdown();
            }
        }
    }
}
