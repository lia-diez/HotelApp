namespace BLL.Classes;

public class Customer
{
    public int Id { get; set; }
    public string PassportId { get; set; }
    public string FirstName{ get; set; }
    public string LastName{ get; set; }
    public Booking[] Bookings { get; set; }
}