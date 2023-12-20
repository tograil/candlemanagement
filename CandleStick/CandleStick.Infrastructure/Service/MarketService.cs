using CandleStick.Infrastructure.Contracts;
using CandleStick.Infrastructure.Models;
using System.Globalization;

namespace CandleStick.Infrastructure.Service;

public class MarketService : IMarketService
{
    private const string TIME_FORMAT = "dd/MM/yyyy HH:mm:ss.fff";

    private IList<MarketLine> _marketLines = new List<MarketLine>();
    private readonly string _csvPath;

    public MarketService(string csvPath)
    {
        _csvPath = csvPath;
        LoadMarketLines();
    }

    public IEnumerable<MarketLine> GetMarketLines()
    {
        return _marketLines;
    }

    public IEnumerable<CandleData> GetCandleData(TimeSpan interval)
    {
        var groupedData = _marketLines.GroupBy(data => new DateTime(data.DateTime.Ticks / interval.Ticks * interval.Ticks))
            .Select(group =>
            {
                var intervalStart = group.Key;
                
                return new CandleData
                {
                    DateTime = intervalStart,
                    OpenPrice = group.First().Price,
                    ClosePrice = group.Last().Price,
                    HighPrice = group.Max(x => x.Price),
                    LowPrice = group.Min(x => x.Price),
                    Quantity = group.Sum(x => x.Quantity)
                };
                
            })
            .ToList();

        return groupedData;
    }

    private void LoadMarketLines()
    {
        _marketLines = File.ReadAllLines(_csvPath)
            .Skip(1)
            .Select(csvLine =>
            {
                var arrLine = csvLine.Split(',');
                var marketLine = new MarketLine
                {
                    DateTime = DateTime.ParseExact(arrLine[0], TIME_FORMAT, CultureInfo.InvariantCulture),
                    Quantity = long.Parse(arrLine[1]),
                    Price = decimal.Parse(arrLine[2])
                };
                
                return marketLine;
            }).OrderBy(x => x.DateTime).ToList();
    }
}