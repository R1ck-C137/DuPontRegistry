using DuPontRegistry.DataAccess;
using DuPontRegistry.DataAccess.Interface;
using DuPontRegistry.Models;
using Newtonsoft.Json.Linq;

namespace DuPontRegistry.Service
{
    public class CarService : ICar
    {
        private readonly ICarDp _carDp;
        private Dictionary<uint, Car> _carList = new();
        
        public CarService(ICarDp carDp)
        {
            _carDp = carDp;
        }
        
        public JObject GetCarById(uint id)
        {
            throw new NotImplementedException();
        }
        
        public JObject GetCarList(int page, int countPageLim, CarFilters? filters)
        {
            throw new NotImplementedException();
        }
    }
}
