using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Classes;

public class Room
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    public int Number { get; set; }
    
    [Required][Range(1, 100)]
    public int Capacity { get; set; }
    
    [Required]
    public virtual Category Category { get; set; }
    
    public virtual List<Booking> Bookings { get; set; }
}