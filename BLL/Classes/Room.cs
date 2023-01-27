namespace BLL.Classes;

public class Room
{
    public int Id { get; set; }
    public int Number { get; set; }
    public Category Category { get; set; }
    public int Capacity { get; set; }
    public double Price { get; }
    
}