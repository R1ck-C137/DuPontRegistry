using DuPontRegistry.Models;

namespace DuPontRegistry.DataAccess.Interface
{
    public interface IBuyerDp : IUserDp
    {
        public int? CrateBuyer(Buyer buyer);
    }
}
