using DuPontRegistry.DataAccess;
using DuPontRegistry.DataAccess.Interface;
using DuPontRegistry.DataProcessor.Util;
using DuPontRegistry.Models;
using Npgsql;

namespace DuPontRegistry.DataProcessor
{
    public class BuyerDp : IBuyerDp
    {
        private readonly ILogger<BuyerDp> _logger;
        private readonly string? _connectionString;
        public BuyerDp( ILogger<BuyerDp> logger, IConfiguration configuration)
        {
            _logger = logger;
            _connectionString = configuration?.GetSection("ConnectionStrings")?.GetValue<string>("DuPontRegistry");
            if (_connectionString == null)
                _logger.LogError("connectionString is null!");
        }

        public int? GetUserId(string login, string? password = null)
        {
            var getUserIdQuery = new NpgsqlCommand($"SELECT \"Id\" FROM public.\"Buyer\" where \"Email\" = @Login");
            getUserIdQuery.Parameters.Add(new NpgsqlParameter("@Login", login));
            if (password != null)
            {
                getUserIdQuery.CommandText += $" and \"Password\" = @Password";
                getUserIdQuery.Parameters.Add(new NpgsqlParameter("@Password", password));
            }

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

        public int? CrateBuyer(Buyer buyer)
        {
            var insertNewBuyer = new NpgsqlCommand(@$"INSERT INTO public.""Buyer"" ({Buyer.GetFields()}) VALUES ({Buyer.GetValuesName()}) RETURNING ""Id""");
            insertNewBuyer.Parameters.Add(new NpgsqlParameter("@Email", buyer.Email));
            insertNewBuyer.Parameters.Add(new NpgsqlParameter("@Password", buyer.Password));
            insertNewBuyer.Parameters.Add(new NpgsqlParameter("@FirstName", buyer.FirstName));
            insertNewBuyer.Parameters.Add(new NpgsqlParameter("@LastName", buyer.LastName));
            insertNewBuyer.Parameters.Add(new NpgsqlParameter("@Phone", buyer.Phone));
            insertNewBuyer.Parameters.Add(new NpgsqlParameter("@CreateDate", buyer.CreateDate));
            insertNewBuyer.Parameters.Add(new NpgsqlParameter("@ModifyDate", buyer.ModifyDate));
            
            try
            {
                return (int?)PGSqlUtil.ExecuteScalar(insertNewBuyer, _connectionString!);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in CrateBuyer: {buyer}");
                return null;
            }
        }
    }
}
