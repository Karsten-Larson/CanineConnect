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
                    .Include(e => e.HomeAddress)
                    .FirstOrDefaultAsync();

                if (user == null)
                {
                    throw new ArgumentException("Email and/or Password is incorrect");
                }

                return user;
            }
        }

        public async Task RegisterUser(string email, string password, string firstname, string lastname, DateOnly age, Address home_address, string? phone=null)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                bool userExists = await context.User
                    .AnyAsync(e => e.Email == email);

                if (userExists)
                {
                    throw new ArgumentException("Email is already used");
                }

                var registeredUser = new User
                {
                    Email = email,
                    Password = password,
                    FirstName = firstname,
                    LastName = lastname,
                    Age = age,
                    HomeAddress = home_address,
                    Phone = phone
                };

                await context.Address.AddAsync(home_address);
                await context.User.AddAsync(registeredUser);
                await context.SaveChangesAsync();
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
