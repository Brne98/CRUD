namespace ExchangeRate.Api;

public class ExchangeRate : Base
{
    public string Currency { get; set; }
    public double Buy { get; set; }
    public double Middle { get; set; }
    public double Sell { get; set; }
}