namespace BLL.Classes;

public class Booking
{
    public int Id { get; set; }
    public Room Room { get; set; }
    public Customer Customer { get; set; }
    public DateTime ArrivalDate { get; set; }
    public DateTime DepartureDate { get; set; }
}