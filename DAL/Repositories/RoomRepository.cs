using DAL.Classes;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class RoomRepository : IRepository<Room>
{
    private HotelDbContext _dbContext;
    private bool _disposed = false;


    public RoomRepository(HotelDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IEnumerable<Room> GetAll()
    {
        return _dbContext.Rooms;
    }

    public Room GetItem(int id)
    {
        var room = _dbContext.Rooms.FirstOrDefault(r => r.Id == id);
        if (room != null) 
            return room;
        throw new Exception();
    }

    public void Create(Room item)
    {
        _dbContext.Rooms.Add(item);
    }
    
    public IEnumerable<Room> Where(Func<Room, bool> predicate)
    {
        return _dbContext.Rooms.Where(predicate);
    }

    public void Update(Room item)
    {
        _dbContext.Entry(item).State = EntityState.Modified;
    }

    public void Delete(int id)
    {
        var room = _dbContext.Rooms.FirstOrDefault(r => r.Id == id);
        if (room != null)
            _dbContext.Rooms.Remove(room);

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