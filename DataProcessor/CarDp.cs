using DuPontRegistry.DataAccess.Interface;
using DuPontRegistry.DataProcessor.Util;
using DuPontRegistry.Models;
using Newtonsoft.Json.Linq;
using Npgsql;

namespace DuPontRegistry.DataProcessor
{
    public class CarDp : ICarDp
    {
        private readonly ILogger<SellerDp> _logger;
        private readonly string? _connectionString;
        public CarDp(IConfiguration configuration, ILogger<SellerDp> logger)
        {
            _logger = logger;
            _connectionString = configuration?.GetSection("ConnectionStrings")?.GetValue<string>("DuPontRegistry");
            if (_connectionString == null)
                _logger.LogError("connectionString is null!");
        }
        
        public Dictionary<uint, Car> GetCarList()
        {
            var getAllCars = new NpgsqlCommand($"SELECT {Car.GetFields()} FROM car");
            var carCollection = new Dictionary<uint, Car>();
            
            PGSqlUtil.ExecuteReader(getAllCars, rdr =>
            {
                carCollection.Add((uint)rdr.GetInt32(0), new Car()
                {
                    
                });
            }, _connectionString!);
            
            return carCollection;
        }
    }
}
