using DuPontRegistry.DataAccess;
using DuPontRegistry.Models;
using DuPontRegistry.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace DuPontRegistry.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : BaseController
    {
        private ISeller _seller;
        private IBuyer _buyer;
        private IUser _user;
        
        public UserController(ISeller seller, IBuyer buyer, IUser user)
        {
            _seller = seller;
            _buyer = buyer;
            _user = user;
        }
        
        [HttpPost]
        [Route("create/seller")]
        public JObject CreateSeller(Seller seller)
        {
            _seller.CreateNewSeller(seller);
            return new JObject();
        }
        
        [HttpPost]
        [Route("create/buyer")]
        public JObject CreateBuyer(Buyer buyer)
        {
            _buyer.CreateNewBuyer(buyer);
            return new JObject();
        }
        
        [HttpPost]
        [Route("login")]
        public JObject Login(string login, string password, UserType type)
        {
            if (_user.Login(login, password, type) == false)
                return new JObject()
                {
                    {"success", false},
                    {"Error", "Email or password is not correct"}, //TODO: возможно нужно сделать другой код ответа
                };
            
            Response.Cookies.Append("sid", _user.Base64Encode(login + ":" + password), _user.GetCookieOptions());
            return new JObject{
                {"success", true},
            };
        }
    }
}
