using DuPontRegistry.DataProcessor.Interface;
using DuPontRegistry.DataProcessor.Util;
using Npgsql;

namespace DuPontRegistry.DataProcessor
{
    public class SellerDp : ISellerDp
    {
        private readonly ILogger<SellerDp> _logger;
        private readonly string? _connectionString;
        public SellerDp(IConfiguration configuration, ILogger<SellerDp> logger)
        {
            _logger = logger;
            _connectionString = configuration?.GetSection("ConnectionStrings")?.GetValue<string>("DuPontRegistry");
        }
        
        public int? GetUserId(string login, string password)
        {
            var getUserIdQuery = new NpgsqlCommand($"SELECT \"Id\" FROM public.\"Seller\" where \"Email\" = \'{login}\' and \"Password\" = \'{password}\'");
            try
            {
                return (int?)PGSqlUtil.ExecuteScalar(getUserIdQuery, _connectionString!);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in ISellerDp.GetUserId; login:{login}, password: {password}");
                return null;
            }
        }
    }
}
