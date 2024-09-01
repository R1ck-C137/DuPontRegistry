using DuPontRegistry.Models.Enums;

namespace DuPontRegistry.Models;

public abstract class User : IBaseModel
{
    public int Id { get; protected set; }
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

    public virtual string GetFields()
    {
        return $@"""{nameof(Email)}"", ""{nameof(Password)}"", ""{nameof(CreateDate)}"", ""{nameof(ModifyDate)}""";
    }

    public virtual string GetValuesName()
    {
        return $"@{nameof(Email)}, @{nameof(Password)}, @{nameof(CreateDate)}, @{nameof(ModifyDate)}";
    }

    public virtual string ToString()
    {
        return $@"{nameof(Email)}:""{Email}"", {nameof(Password)}:""{Password}"", {nameof(CreateDate)}:""{CreateDate}"", {nameof(ModifyDate)}:""{ModifyDate}""";
    }
}