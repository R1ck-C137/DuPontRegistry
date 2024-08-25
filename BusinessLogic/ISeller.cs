using DuPontRegistry.Models;
using DuPontRegistry.Models.Enums;
using Newtonsoft.Json.Linq;

namespace DuPontRegistry.DataAccess
{
    public interface ISeller
    {
        public JObject CreateNewSeller(Seller seller);
    }
}
