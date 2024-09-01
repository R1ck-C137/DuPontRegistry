using DuPontRegistry.DataAccess;
using DuPontRegistry.DataProcessor.Interface;
using DuPontRegistry.Models;
using DuPontRegistry.Services;

namespace DuPontRegistry.Service
{
    public class SellerService : ISeller
    {
        private readonly ISellerDp _sellerDp;
        private readonly ILogger<BuyerService> _logger;
        public SellerService(ISellerDp sellerDp, ILogger<BuyerService> logger)
        {
            _sellerDp = sellerDp;
            _logger = logger;
        }
        public int? CreateNewSeller(Seller seller)
        {
            if (_sellerDp.GetUserId(seller.Email) == null) 
                return _sellerDp.CrateSeller(seller);
            
            _logger.LogWarning($"Attempt to create a new user with an existing username {seller.Email}");
            throw new InvalidDataException("A user with this username already exists");
        }
    }
}
