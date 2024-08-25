using DuPontRegistry.Models.Enums;
using Newtonsoft.Json.Linq;

namespace DuPontRegistry.DataAccess
{
    public interface IUser
    {
        public bool Login(string login, string password, UserType type);
        public string Base64Encode(string plainText);
        public CookieOptions GetCookieOptions();
    }
}
