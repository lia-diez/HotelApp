using DAL.Repositories;

namespace DAL;

public interface IRepositoryProvider
{
    public BookingRepository Bookings { get; }
    public CategoryRepository Categories { get; }
    public CustomerRepository Customers { get; }
    public RoomRepository Rooms { get; }
    public void Save();
}