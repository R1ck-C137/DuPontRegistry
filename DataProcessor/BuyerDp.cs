using DuPontRegistry.DataAccess.Interface;
using DuPontRegistry.DataProcessor.Util;
using Npgsql;

namespace DuPontRegistry.DataProcessor
{
    public class BuyerDp : IBuyerDp
    {
        private readonly ILogger<BuyerDp> _logger;
        private readonly string? _connectionString;
        public BuyerDp(IConfiguration configuration, ILogger<BuyerDp> logger)
        {
            _logger = logger;
            _connectionString = configuration?.GetSection("ConnectionStrings")?.GetValue<string>("DuPontRegistry");
        }
        
        public int? GetUserId(string login, string password)
        {
            var getUserIdQuery = new NpgsqlCommand($"SELECT \"Id\" FROM public.\"Buyer\" where \"Email\" = \'{login}\' and \"Password\" = \'{password}\'");
            try
            {
                return (int?)PGSqlUtil.ExecuteScalar(getUserIdQuery, _connectionString!);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in IBuyerDp.GetUserId; login:{login}, password: {password}");
                return null;
            }
        }
    }
}
