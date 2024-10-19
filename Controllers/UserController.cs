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
        private readonly ISeller _seller;
        private readonly IBuyer _buyer;
        private readonly IUser _user;
        private readonly ILogger<UserController> _logger;
        
        public UserController(ISeller seller, IBuyer buyer, IUser user, ILogger<UserController> logger)
        {
            _seller = seller;
            _buyer = buyer;
            _user = user;
            _logger = logger;
        }
        
        [HttpPost]
        [Route("create/seller")]
        public JObject CreateSeller(Seller seller)
        {
            try
            {
                var idNewSeller = _seller.CreateNewSeller(seller);
                Response.StatusCode = 201;
                return new JObject()
                {
                    { "success", true },
                    { "Id", idNewSeller }
                };
            }
            catch (InvalidDataException ex)
            {
                Response.StatusCode = 400;
                return new JObject()
                {
                    { "success", false },
                    { "Error", ex.Message }
                };
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                _logger.LogError(ex.ToString());
                return new JObject()
                {
                    { "success", false },
                };
            }
        }
        
        [HttpPost]
        [Route("create/buyer")]
        public JObject CreateBuyer(Buyer buyer)
        {
            try
            {
                var idNewBuyer = _buyer.CreateNewBuyer(buyer);
                Response.StatusCode = 201;
                return new JObject()
                {
                    { "success", true },
                    { "Id", idNewBuyer }
                };
            }
            catch (InvalidDataException ex)
            {
                Response.StatusCode = 400;
                return new JObject()
                {
                    { "success", false },
                    { "Error", ex.Message }
                };
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                _logger.LogError(ex.ToString());
                return new JObject()
                {
                    { "success", false },
                };
            }
        }
        
        [HttpPost]
        [Route("login")]
        public JObject Login(string login, string password, UserType type)
        {
            if (_user.Login(login, password, type) == false)
            {
                Response.StatusCode = 401;
                return new JObject()
                {
                    { "success", false },
                    { "Error", "Email or password is not correct" },
                };
            }

            Response.Cookies.Append("sid", _user.Base64Encode(login + ":" + password), _user.GetCookieOptions());
            return new JObject{
                {"success", true}
            };
        }
        
        [HttpPost]
        [Route("logout")]
        public JObject Logout()
        {
            Response.Cookies.Delete("sid");
            return new JObject()
            {
                {"success", true}
            };
        }
    }
}
