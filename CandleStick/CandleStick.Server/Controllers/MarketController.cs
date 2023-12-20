using CandleStick.Infrastructure.Contracts;
using CandleStick.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace CandleStick.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MarketController : ControllerBase
    {
        private readonly IMarketService _marketService;

        public MarketController(IMarketService marketService)
        {
            _marketService = marketService;
        }

        [HttpGet(Name = "GetMarket")]
        public IEnumerable<CandleData> Get()
        {
            return _marketService.GetCandleData(TimeSpan.FromMinutes(1));
        }
    }
}
