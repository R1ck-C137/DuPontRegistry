namespace DuPontRegistry.DataAccess.Interface
{
    public interface IUserDp
    {
        public int? GetUserId(string login, string password);
    }
}
