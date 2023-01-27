using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Classes;

public class Booking
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Required]
    // [ForeignKey("BookingId")] //todo: РОЗІБРАТЬСЯ ЯК ЦЕ РОБИТЬ БО Я НІФІГА НЕ ПОНІМАЮ
    public virtual Room Room { get; set; }
    
    [Required]
    // [ForeignKey("BookingId")]
    public virtual Customer Customer { get; set; }
    
    [Required]
    public DateTime ArrivalDate { get; set; }
    
    [Required]
    public DateTime DepartureDate { get; set; }
}