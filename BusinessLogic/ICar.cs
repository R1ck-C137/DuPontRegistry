using DuPontRegistry.Models;
using Newtonsoft.Json.Linq;

namespace DuPontRegistry.DataAccess
{
    public interface ICar
    {
        public JObject GetCarById(uint id);
        public JObject GetCarList(int page, int countPageLim, CarFilters? filters);
    }
}
