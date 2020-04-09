using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPIApp.Data;
using WebAPIApp.Models;

namespace WebAPIApp
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext dataContext;

        public UserRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        
        public async Task<User> GetUser(long userId)
        {
            return await dataContext.Users.FirstAsync(it => it.Id == userId);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await dataContext.Users.ToListAsync();
        }

        public async Task<User> GetUserByEmail(string userEmail)
        {
            return await dataContext.Users
                .SingleOrDefaultAsync(it => it.Email.ToLower().Equals(userEmail.ToLower()));
        }

        public async Task<User> AddUser(User user)
        {
            dataContext.Users.Add(user);
            await dataContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUser(User user)
        {
            dataContext.Users.Update(user);
            await dataContext.SaveChangesAsync();
            return user;
        }
    }
}