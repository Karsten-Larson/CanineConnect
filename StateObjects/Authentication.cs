using CanineConnect.Data;
using CanineConnect.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace CanineConnect.StateObjects
{
    public class Authentication
    {

        private readonly IDbContextFactory<CanineConnectContext> _dbContextFactory;

        public Authentication(IDbContextFactory<CanineConnectContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<List<User>> GetUsers()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return await context.User.ToListAsync();
            }
        }

        public async Task<User> AuthenticateUser(string email, string password)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var user = await context.User
                    .Where(e => e.Email == email)
                    .Where(e => e.Password == password)
                    .FirstOrDefaultAsync();

                if (user == null)
                {
                    throw new ArgumentException("Email and/or Password is incorrect");
                }

                return user;
            }
        }

        public async Task<List<Shelter>> FindShelters(string name)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return await context.Shelter
                    .Where(e => e.ShelterName == name)
                    .ToListAsync();
            }
        }

        public async Task<List<User>> FindUsers(string name)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                return await context.User
                    .Where(e => e.FirstName == name)
                    .ToListAsync();
            }
        }
    }
}
