using AutoMapper;
using BLL.Classes;
using DAL;

namespace BLL.Services;

public class FindFreeRoomsByDate
{
    private IRepositoryProvider _repoProvider;
    private Mapper _mapper;

    public FindFreeRoomsByDate(IRepositoryProvider repoProvider)
    {
        _repoProvider = repoProvider;
        _mapper = new Mapper(new MapperConfiguration((
            config => config.CreateMap<DAL.Classes.Room, Room>())));
    }

    public IEnumerable<Room> FindFreeRooms(DateTime arrivalDate, DateTime departureDate)
    {

        var rooms = _repoProvider.Rooms
            .GetAll() //Todo: remove nahui
            .Where(r =>
                !r.Bookings.Any(b => (b.DepartureDate > arrivalDate && b.ArrivalDate < departureDate) ||
                (b.ArrivalDate > arrivalDate && b.ArrivalDate < departureDate)));
        
        return _mapper.Map<IEnumerable<Room>>(rooms);
    }

    private bool Intersects((DateTime left, DateTime right) check, (DateTime left, DateTime right) other)
    {
        return IsBetween(check.left, other) || IsBetween(check.right, other) || 
               IsBetween(other.left, check) || IsBetween(other.right, check);
    }

    private bool IsBetween(DateTime check, (DateTime left, DateTime right) other) =>
        check >= other.left && check <= other.right;
}