using DuPontRegistry.Models;
using Newtonsoft.Json.Linq;

namespace DuPontRegistry.DataAccess
{
    public interface IBuyer
    {
        public int? CreateNewBuyer(Buyer buyer);
    }
}
