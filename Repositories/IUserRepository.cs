using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIApp.Entities;

namespace WebAPIApp
{
    public interface IUserRepository
    {
        public Task<User> GetUser(long userId);
        public Task<IEnumerable<User>> GetUsers();
        public Task<User> GetUserByEmail(string userEmail);
        public Task<User> AddUser(User user);
        public Task<User> UpdateUser(User user);
    }
}