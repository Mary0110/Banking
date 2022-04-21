using bank5.Entities.UserCategories;

namespace bank5.Entities;

public class Bill
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Money { get; set; }
    public int? ClientId { get; set; }
    public Client Client { get; set; }
    public int? BankId { get; set; }
    public Bank Bank { get; set; }
    public int? FactoryId { get; set; }
    public State State { get; set; }
}

public enum State
{
    Active,
    Blocked,
    Freezed
}