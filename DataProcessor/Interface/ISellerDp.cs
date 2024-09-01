using DuPontRegistry.DataAccess.Interface;
using DuPontRegistry.Models;

namespace DuPontRegistry.DataProcessor.Interface
{
    public interface ISellerDp : IUserDp
    {
        public int? CrateSeller(Seller seller);
    }
}
