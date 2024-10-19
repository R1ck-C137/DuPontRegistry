using DuPontRegistry.DataProcessor.Interface;
using DuPontRegistry.DataProcessor.Util;
using DuPontRegistry.Models;
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
            if (_connectionString == null)
                _logger.LogError("connectionString is null!");
        }
        
        public int? GetUserId(string login, string? password = null)
        {
            var getUserIdQuery = new NpgsqlCommand($"SELECT \"Id\" FROM public.\"Seller\" where \"Email\" = \'{login}\'");
            if (password != null)
                getUserIdQuery.CommandText += $" and \"Password\" = \'{password}\'";
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

        public int? CrateSeller(Seller seller)
        {
            var insertNewSeller = new NpgsqlCommand(@$"INSERT INTO public.""Seller"" ({Seller.GetFields()}) VALUES ({Seller.GetValuesName()}) RETURNING ""Id""");
            insertNewSeller.Parameters.Add(new NpgsqlParameter("@Email", seller.Email));
            insertNewSeller.Parameters.Add(new NpgsqlParameter("@Password", seller.Password));
            insertNewSeller.Parameters.Add(new NpgsqlParameter("@Title", seller.Title));
            insertNewSeller.Parameters.Add(new NpgsqlParameter("@Web", seller.Web));
            insertNewSeller.Parameters.Add(new NpgsqlParameter("@City", seller.City));
            insertNewSeller.Parameters.Add(new NpgsqlParameter("@Logo", seller.Logo));
            insertNewSeller.Parameters.Add(new NpgsqlParameter("@Descr", seller.Descr));
            insertNewSeller.Parameters.Add(new NpgsqlParameter("@Metro", seller.Metro));
            insertNewSeller.Parameters.Add(new NpgsqlParameter("@State", seller.State));
            insertNewSeller.Parameters.Add(new NpgsqlParameter("@Contact", seller.Contact));
            insertNewSeller.Parameters.Add(new NpgsqlParameter("@CreateDate", seller.CreateDate));
            insertNewSeller.Parameters.Add(new NpgsqlParameter("@ModifyDate", seller.ModifyDate));
            
            try
            {
                return (int?)PGSqlUtil.ExecuteScalar(insertNewSeller, _connectionString!);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error in CrateBuyer: {seller}");
                return null;
            }
        }
    }
}
