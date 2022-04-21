namespace bank5.Entities;

public class Transfer
{
    public int id { get; set; }
    
    public int FromId { get; set; }
    public int ToId { get; set; }
    public int Money { get; set; }
    
    public bool Display { get; set; }
}