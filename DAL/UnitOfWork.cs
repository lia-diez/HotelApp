using DAL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class UnitOfWork : IDisposable, IRepositoryProvider
{
    private readonly HotelDbContext _dbContext;
    private bool _isDisposed = false;

    private BookingRepository? _bookingRepository;
    private CategoryRepository? _categoryRepository;
    private CustomerRepository? _customerRepository;
    private RoomRepository? _roomRepository;

    public UnitOfWork(HotelDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public BookingRepository Bookings => _bookingRepository ??= new BookingRepository(_dbContext);
    public CategoryRepository Categories => _categoryRepository ??= new CategoryRepository(_dbContext);
    public CustomerRepository Customers => _customerRepository ??= new CustomerRepository(_dbContext);
    public RoomRepository Rooms => _roomRepository ??= new RoomRepository(_dbContext);

    public virtual void Dispose(bool disposing)
    {
        if (!_isDisposed)
        {
            if (disposing)
                _dbContext.Dispose();
            _isDisposed = true;
        }
    }
    
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }
}