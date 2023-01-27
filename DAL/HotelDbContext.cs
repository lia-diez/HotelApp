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

    
    
    
    
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Room>().HasData(new List<Room>() { 
    //         new Room() { Capacity = 12, Number = 12, Id = 1}, 
    //         new Room() { Capacity = 123, Number = 123, Id = 2},
    //     });
    // }
}