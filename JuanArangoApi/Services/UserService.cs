using JuanArangoApi.Data;
using JuanArangoApi.Data.Models;
using JuanArangoApi.Services;
using Microsoft.EntityFrameworkCore;

namespace JuanArangoApi.API.Services
{
    public class UserService : IUserService
    {

        private readonly JuanArangoApiContext _context;


        public UserService(JuanArangoApiContext context)
        {
            _context = context;
        }

        public async Task<User>? GetUserAsync(string username, string password)
        {
            if (_context.User == null)
            {
                return null;
            }
            var user = await _context.User.FirstOrDefaultAsync(user => user.UserName == username && user.Password == password);

            return user;
        }
    }
}
