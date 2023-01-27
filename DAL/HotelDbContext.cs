using System.Reflection.Metadata.Ecma335;
using DAL.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DAL;

public class HotelDbContext : DbContext
{
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Booking> Bookings { get; set; }

    private IConfiguration _config;
    public HotelDbContext(IConfiguration config)
    {
        _config = config;
        Database.EnsureCreated();
        
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_config.GetConnectionString("Default"));
    }

    // protected override void OnModelCreating(DbModelBuilder modelBuilder)
    // {
    //     
    // }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var categories = new List<Category>
        {
            new() { Cost = 100, Type = "standard" },
            new() { Cost = 150, Type = "semilux" },
            new() { Cost = 300, Type = "lux" }
        };

        var rooms = new List<Room>
        {
            new() { Capacity = 2, Category = categories[0], Number = 101 },
            new() { Capacity = 3, Category = categories[1], Number = 201 },
            new() { Capacity = 1, Category = categories[1], Number = 202 },
            new() { Capacity = 5, Category = categories[2], Number = 301 }
        };

        var customers = new List<Customer>
        {
            new() { FirstName = "Petro", LastName = "Petrovych", PassportId = "111" },
            new() { FirstName = "Ivan", LastName = "Ivanovych", PassportId = "222" },
            new() { FirstName = "Olexandr", LastName = "Olexandrovych", PassportId = "333" },
            new() { FirstName = "Danylo", LastName = "Danylovych", PassportId = "444" }
        };

        var random = new Random(0);
        var bookings = new List<Booking>();

        for (int i = 0; i < 4; i++)
        {
            var arrival = new DateTime(2023, random.Next(1, 6), random.Next(1, 28));
            var departure = arrival.AddDays(random.Next(1, 7));
            var newBooking = new Booking()
            {
                ArrivalDate = arrival, DepartureDate = departure, Customer = customers[i], Room = rooms[i]
            };
            customers[i].Bookings = new List<Booking> { newBooking };
            bookings.Add(newBooking);
        }

        modelBuilder.Entity<Category>().HasData(categories);
        modelBuilder.Entity<Customer>().HasData(customers);
        modelBuilder.Entity<Room>().HasData(rooms);
        modelBuilder.Entity<Booking>().HasData(bookings);
    }
}