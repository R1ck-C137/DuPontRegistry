using DuPontRegistry.DataAccess;
using DuPontRegistry.DataAccess.Interface;
using DuPontRegistry.Models;
using Newtonsoft.Json.Linq;

namespace DuPontRegistry.Services
{
    public class BuyerService : IBuyer
    {
        private readonly IBuyerDp _buyerDp;
        private readonly ILogger<BuyerService> _logger;
        public BuyerService(IBuyerDp buyerDp, ILogger<BuyerService> logger)
        {
            _buyerDp = buyerDp;
            _logger = logger;
        }
        public int? CreateNewBuyer(Buyer buyer)
        {
            if (_buyerDp.GetUserId(buyer.Email) == null) 
                return _buyerDp.CrateBuyer(buyer);
            
            _logger.LogWarning($"Attempt to create a new user with an existing username {buyer.Email}");
            throw new InvalidDataException("A user with this email already exists");
        }
    }
}
