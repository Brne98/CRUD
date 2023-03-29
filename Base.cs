namespace ExchangeRate.Api;

public class Base
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}