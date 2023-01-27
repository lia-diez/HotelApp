using BLL.Classes;
using DAL;

namespace BLL.Services;

public class BookRoom
{
    private IRepositoryProvider _unitOfWork;

    public BookRoom(IRepositoryProvider unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public bool Book(Customer customer, Room room)
    {
        return true;
    }
    
}