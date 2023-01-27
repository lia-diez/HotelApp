using DAL.Classes;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class BookingRepository : IRepository<Booking>
{
    private HotelDbContext _dbContext;
    private bool _disposed = false;

    public BookingRepository(HotelDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public IEnumerable<Booking> GetAll()
    {
        return _dbContext.Bookings;
    }

    public Booking GetItem(int id)
    {
        var booking = _dbContext.Bookings.FirstOrDefault(b => b.Id == id);
        if (booking != null) 
            return booking;
        throw new KeyNotFoundException();
    }

    public void Create(Booking item)
    {
        _dbContext.Bookings.Add(item);
    }

    public void Update(Booking item)
    {
        _dbContext.Entry(item).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        var booking = _dbContext.Bookings.FirstOrDefault(b => b.Id == id);
        if (booking != null) 
            _dbContext.Bookings.Remove(booking);
    }

    public void SaveChanges()
    {
        _dbContext.SaveChanges();
    }
    
    public virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
                _dbContext.Dispose();
            _disposed = true;
        }
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}