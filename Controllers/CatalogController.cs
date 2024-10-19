using DuPontRegistry.BusinessLogic;
using DuPontRegistry.DataAccess;
using DuPontRegistry.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace DuPontRegistry.Controllers
{
    [Route("catalog")]
    [ApiController]
    public class CatalogController : BaseController
    {
        private readonly ICar _carServise;
        
        public CatalogController(ICar carServise)
        {
            _carServise = carServise;
        }

        [Route("read")]
        [HttpGet]
        public JObject ReadCarById(uint id)
        {
            throw new NotImplementedException();
        }
        
        [Route("list")]
        [HttpGet]
        public JObject ReadCarList(int page = 1, int countPageLim = 20, CarFilters? filters = null)
        {
            throw new NotImplementedException();
        }
    }
}