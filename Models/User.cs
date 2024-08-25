using DuPontRegistry.Models.Enums;

namespace DuPontRegistry.Models;

public class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserType Type { get; set; }
    public DateTime CreateDate { get; private set; }
    public DateTime ModifyDate { get; private set; }

    public void SetCreateDate(DateTime createDate)
    {
        CreateDate = createDate;
    }
        
    public void SetModifyDate(DateTime modifyDate)
    {
        ModifyDate = modifyDate;
    }
}