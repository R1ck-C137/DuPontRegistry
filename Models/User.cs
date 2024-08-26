using DuPontRegistry.Models.Enums;

namespace DuPontRegistry.Models;

public abstract class User
{
    public int Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserType Type { get; set; }
    public DateTime CreateDate { get; protected set; }
    public DateTime ModifyDate { get; protected set; }

    public void SetCreateDate(DateTime createDate)
    {
        CreateDate = createDate;
    }
        
    public void SetModifyDate(DateTime modifyDate)
    {
        ModifyDate = modifyDate;
    }

    public abstract string GetFields();
    public abstract string GetValues();
}