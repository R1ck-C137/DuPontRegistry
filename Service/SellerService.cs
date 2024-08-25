using DuPontRegistry.DataAccess;
using DuPontRegistry.DataAccess.Interface;
using DuPontRegistry.DataProcessor.Interface;
using DuPontRegistry.Models;
using DuPontRegistry.Models.Enums;
using Newtonsoft.Json.Linq;

namespace DuPontRegistry.Services
{
    public class SellerService : ISeller
    {
        private ISellerDp _sellerDp;

        public SellerService(ISellerDp sellerDp)
        {
            _sellerDp = sellerDp;
        }
        
        public JObject CreateNewSeller(Seller seller)
        {
            throw new NotImplementedException();
        }
    }
}
