namespace CandleStick.Infrastructure.Models;

public class CandleData
{
    public decimal OpenPrice { get; set; }
    public decimal ClosePrice { get; set; }
    public decimal HighPrice { get; set; }
    public decimal LowPrice { get; set; }
    public DateTime DateTime { get; set; }
    public long Quantity { get; set; }
}