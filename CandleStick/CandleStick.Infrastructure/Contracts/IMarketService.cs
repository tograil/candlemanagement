using CandleStick.Infrastructure.Models;

namespace CandleStick.Infrastructure.Contracts;

public interface IMarketService
{
    IEnumerable<MarketLine> GetMarketLines();
    IEnumerable<CandleData> GetCandleData(TimeSpan interval);
}