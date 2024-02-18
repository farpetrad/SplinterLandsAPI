namespace SplinterLandsAPI
{
    public interface ILogin
    {
        string Login(string username, string signature, string ts);
        Task<string> LoginAsync(string username, string signature, string ts);
    }
}
