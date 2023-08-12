using JuanArangoApi.Data.Models;

namespace JuanArangoApi.Services
{
    public interface IUserService
    {
        Task<User>? GetUserAsync(string username, string password);
    }
}


