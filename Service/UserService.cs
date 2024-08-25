using DuPontRegistry.DataAccess;
using DuPontRegistry.DataAccess.Interface;
using DuPontRegistry.DataProcessor.Interface;
using DuPontRegistry.Models.Enums;

namespace DuPontRegistry.Service;

public class UserService : IUser
{
    private readonly IBuyerDp _buyerDp;
    private readonly ISellerDp _sellerDp;
    private Dictionary<int, UserType> loggedUsersByType = new Dictionary<int, UserType>();

    public UserService(IBuyerDp buyerDp, ISellerDp sellerDp)
    {
        _buyerDp = buyerDp;
        _sellerDp = sellerDp;
    }
    
    public bool Login(string login, string password, UserType type)
    {
        int? idExistingUser = TryGetUserId(login, password, type);
        if (idExistingUser != null)
        {
            loggedUsersByType.Add((int)idExistingUser,type);
            return true;
        }
        return false;
    }

    public string Base64Encode(string plainText)
    {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return Convert.ToBase64String(plainTextBytes);
    }

    public CookieOptions GetCookieOptions()
    {
        return new CookieOptions()
        {
            Path = "/", 
            Expires = DateTime.UtcNow.AddDays(365), 
            SameSite = Microsoft.AspNetCore.Http.SameSiteMode.None,
            Secure = true
        };
    }

    private int? TryGetUserId(string login, string password, UserType type)
    {
        switch (type)
        {
            case UserType.Seller:
                return _sellerDp.GetUserId(login, password);
            case UserType.Buyer:
                return _buyerDp.GetUserId(login, password);
            default:
                return null;
        }
    }
}