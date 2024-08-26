using DuPontRegistry.DataAccess;
using DuPontRegistry.DataAccess.Interface;
using DuPontRegistry.Models;
using Newtonsoft.Json.Linq;

namespace DuPontRegistry.Services
{
    public class BuyerService : IBuyer
    {
        private IBuyerDp _buyerDp;

        public BuyerService(IBuyerDp buyerDp)
        {
            _buyerDp = buyerDp;
        }
        public int? CreateNewBuyer(Buyer buyer)
        {
            return _buyerDp.CrateBuyer(buyer);
        }
    }
}
