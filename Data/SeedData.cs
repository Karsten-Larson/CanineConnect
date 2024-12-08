﻿using Microsoft.EntityFrameworkCore;
using CanineConnect.Models;

namespace CanineConnect.Data;

public class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new CanineConnectContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<CanineConnectContext>>());

        if (context is null || context.User is null || context.Address is null || context.Event is null || context.Shelter is null || context.DogListing is null)
        {
            throw new NullReferenceException(
                "Null CanineConnect Database");
        }

        //context.Event.ExecuteDelete();
        //context.Shelter.ExecuteDelete();
        //context.User.ExecuteDelete();
        //context.Address.ExecuteDelete();
        //context.DogListing.ExecuteDelete();

        if (context.User.Any() || context.Address.Any() || context.Event.Any() || context.Shelter.Any() || context.DogListing.Any())
        {
            return;
        }

        // Addresses
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
        Address address4 = new Address
        {
            Street = "Lincoln Park 14th St S",
            City = "Fargo",
            State = "North Dakota",
            Country = "USA",
            PostalCode = "58103"
        };

        // Users
        User user1 = new User
        {
            FirstName = "Anne",
            LastName = "Denton",
            Email = "anne.denton@ndsu.edu",
            Password = "1234",
            Age = new DateOnly(2004, 10, 27),
            HomeAddress = address1,
        };
        User user2 = new User
        {
            FirstName = "Ken",
            LastName = "Magel",
            Email = "ken.magel@ndsu.edu",
            Password = "1234",
            Age = new DateOnly(2004, 10, 27),
            HomeAddress = address1,
        };
        User user3 = new User
        {
            FirstName = "James",
            LastName = "Dean",
            Email = "james.dean@ndsu.edu",
            Password = "abcd",
            Age = new DateOnly(2005, 1, 17),
            HomeAddress = address2,
        };
        User user4 = new User
        {
            FirstName = "Oksana",
            LastName = "Myronovych",
            Email = "oksana.myronovych@ndsu.edu",
            Password = "2222",
            Age = new DateOnly(1970, 12, 2),
            HomeAddress = address3,
        };

        // Shelters 
        Shelter shelter1 = new Shelter
        {
            ShelterName = "Humane Society",
            Description = "No Kill Dog Shelter based out of Fargo, North Dakota",
            User = user1,
        };
        Shelter shelter2 = new Shelter
        {
            ShelterName = "The Pound INC",
            Description = "Pitbull and Rottweiler only dog pound",
            User = user3,
        };
        Shelter shelter3 = new Shelter
        {
            ShelterName = "Fargo PetSmart",
            Description = "Fargo branch of PetSmart",
            User = user4,
        };

        // Events
        Event event1 = new Event
        {
            Name = "Animal Rescue Day",
            Date = new DateTime(new DateOnly(2025, 1, 1), new TimeOnly(14, 0)),
            Description = "Start the new year off right by volunteering at the dog shelter.",
            Location = address4,
            Host = shelter1
        };
        Event event2 = new Event
        {
            Name = "Christmas at the Pound",
            Date = new DateTime(new DateOnly(2024, 12, 25), new TimeOnly(10, 0)),
            Description = "Experience Christmas at the Pound with the dogs. Santa will join us to bring treats for the pups and humans too!",
            Location = shelter2.User.HomeAddress,
            Host = shelter2
        };
        Event event3 = new Event
        {
            Name = "Valentines Day At the Pound",
            Date = new DateTime(new DateOnly(2025, 2, 14), new TimeOnly(16, 0)),
            Description = "Spend Valentines day around dogs in need of a home. Bring a significant otehr to help and enjoy time together in service of these dogs and the community.",
            Location = shelter2.User.HomeAddress,
            Host = shelter2
        };
        Event event4 = new Event
        {
            Name = "Red, White, and Roof",
            Date = new DateTime(new DateOnly(2025, 6, 4), new TimeOnly(12, 0)),
            Description = "July 4th at Lincoln Park deserves to be celebrated with friends, fellow Americans, and dogs in need of a home. This event is an adoption event that requires volunteers to run smoothly. Please come and help out on our Nation's birthday!",
            Location = address4,
            Host = shelter3
        };

        // DogListings
        DogListing listing1 = new DogListing
        {
            Name = "Rocky",
            Sex = "Male",
            Breed = "Border Collie",
            Weight = 60.0m,
            Age = new DateOnly(2024, 11, 15),
            Shelter = shelter1,
            ThumbnailImage = File.ReadAllBytes("Data\\collie.jpg")
        };
        DogListing listing2 = new DogListing
        {
            Name = "Lexus",
            Sex = "Female",
            Breed = "Shih Tzu",
            Weight = 20.0m,
            Age = new DateOnly(2024, 8, 10),
            Shelter = shelter2,
            ThumbnailImage = File.ReadAllBytes("Data\\shih-tzu.jpg")
        };
        DogListing listing3 = new DogListing
        {
            Name = "Blue",
            Sex = "Female",
            Breed = "Australian Shepherd",
            Weight = 40.0m,
            Age = new DateOnly(2020, 7, 11),
            Shelter = shelter3,
            ThumbnailImage = File.ReadAllBytes("Data\\shepherd.jpg")
        }; 
        DogListing listing4 = new DogListing
        {
            Name = "Duke",
            Sex = "Male",
            Breed = "Great Dane",
            Weight = 120.0m,
            Age = new DateOnly(2019, 5, 12),
            Shelter = shelter3,
            ThumbnailImage = File.ReadAllBytes("Data\\great-dane.png")
        };
        DogListing listing5 = new DogListing
        {
            Name = "Princess",
            Sex = "Female",
            Breed = "Pitbull",
            Weight = 82.5m,
            Description = "The most loving dog you could ever meet",
            Age = new DateOnly(2019, 5, 12),
            Shelter = shelter2,
            ThumbnailImage = File.ReadAllBytes("Data\\pitbull.jpg")
        };

        // Add to the database
        context.Address.AddRange(address1, address2, address3, address4);
        context.User.AddRange(user1, user2, user3, user4);
        context.Shelter.AddRange(shelter1, shelter2, shelter3);
        context.Event.AddRange(event1, event2, event3, event4);
        context.DogListing.AddRange(listing1, listing2, listing3, listing4, listing5);

        context.SaveChanges();
    }
}