using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Classes;

public class Customer
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    public string PassportId { get; set; }
    
    [Required][MaxLength(32)] 
    public string FirstName{ get; set; }
    
    [Required][MaxLength(32)]
    public string LastName{ get; set; }
    
    // [ForeignKey("CustomerId")]
    public virtual List<Booking> Bookings { get; set; }
}