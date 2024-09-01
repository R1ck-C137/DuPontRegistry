namespace DuPontRegistry.DataProcessor.Interface
{
    public interface IUserDp
    {
        public int? GetUserId(string login, string? password = null);
    }
}
