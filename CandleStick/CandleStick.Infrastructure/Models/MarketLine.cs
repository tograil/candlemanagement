namespace CandleStick.Infrastructure.Models;

public class MarketLine
{
    public DateTime DateTime { get; set; }
    public long Quantity { get; set; }
    public decimal Price { get; set; }
}