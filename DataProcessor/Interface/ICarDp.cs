using DuPontRegistry.Models;

namespace DuPontRegistry.DataAccess.Interface
{
    public interface ICarDp
    {
        public Dictionary<uint, Car> GetCarList();
    }
}
