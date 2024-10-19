using DuPontRegistry.Models.Enums;

namespace DuPontRegistry.Models;

public abstract class User
{
    public int Id { get; protected set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public UserType Type { get; set; }
    public DateTime CreateDate { get; protected set; }
    public DateTime ModifyDate { get; protected set; }

    protected static string UserFields =>
        $@"""{nameof(Email)}"", ""{nameof(Password)}"", ""{nameof(CreateDate)}"", ""{nameof(ModifyDate)}""";

    protected static string UserValuesName =>
        $"@{nameof(Email)}, @{nameof(Password)}, @{nameof(CreateDate)}, @{nameof(ModifyDate)}";

    protected string UserToString =>
        $@"{nameof(Email)}:""{Email}"", {nameof(Password)}:""{Password}"", {nameof(CreateDate)}:""{CreateDate}"", {nameof(ModifyDate)}:""{ModifyDate}""";

    public void SetCreateDate(DateTime createDate)
    {
        CreateDate = createDate;
    }
        
    public void SetModifyDate(DateTime modifyDate)
    {
        ModifyDate = modifyDate;
    }
}