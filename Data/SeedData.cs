using Microsoft.EntityFrameworkCore;
using CanineConnect.Models;

namespace CanineConnect.Data;

public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new CanineConnectContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<CanineConnectContext>>());

        if (context is null || context.User is null || context.Address is null)
        {
            throw new NullReferenceException(
                "Null BlazorWebAppMoviesContext or Student DbSet");
        }

        if (context.User.Any() || context.Address.Any())
        {
            return;
        }

        Address address1 = new Address
        {
            Street = "123 Easy St",
            City = "Fargo",
            State = "North Dakota",
            Country = "USA",
            PostalCode = "58102"
        };
        Address address2 = new Address
        {
            Street = "1256 2nd Ave",
            City = "Grand Forks",
            State = "North Dakota",
            Country = "USA",
            PostalCode = "58201"
        };
        Address address3 = new Address
        {
            Street = "University Dr N",
            City = "Fargo",
            State = "North Dakota",
            Country = "USA",
            PostalCode = "58102"
        };

        context.Address.AddRange(address1, address2, address3);

        context.User.AddRange(
            new User
            {
                FirstName = "Anne",
                LastName = "Denton",
                Email = "anne.denton@ndsu.edu",
                Password = "1234",
                Age = new DateOnly(2004, 10, 27),
                HomeAddress = address1,
            },
           new User
           {
               FirstName = "James",
               LastName = "Dean",
               Email = "james.dean@ndsu.edu",
               Password = "abcd",
               Age = new DateOnly(2005, 1, 17),
               HomeAddress = address2,
           }, new User
           {
               FirstName = "Oksana",
               LastName = "Myronovych",
               Email = "oksana.myronovych@ndsu.edu",
               Password = "2222",
               Age = new DateOnly(1970, 12, 2),
               HomeAddress = address3,
           });

        context.SaveChanges();
    }
}