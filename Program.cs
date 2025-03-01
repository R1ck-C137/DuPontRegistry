
using NLog.Extensions.Logging;
using NLog;
using NLog.Web;

namespace DuPontRegistry
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
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

                
                app.UseSwagger();
                app.UseSwaggerUI();

                app.UseHttpsRedirection();

                app.UseAuthorization();

                app.MapControllers();

                app.Run();

                logger.Info("App started");
            }
            catch (Exception exception)
            {
                logger.Error(exception, "Stopped program because of exception");
                throw;
            }
            finally
            {
                LogManager.Shutdown();
            }
        }
    }
}
