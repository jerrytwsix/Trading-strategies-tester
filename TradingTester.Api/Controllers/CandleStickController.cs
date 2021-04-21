using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Binance.Net;
using CryptoExchange.Net.ExchangeInterfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TradingTester.Api.Controllers
{
    public class CandleStick
    {
        public DateTime OpenTime { get; }
        public decimal Open { get; }
        public decimal High { get; }
        public decimal Low { get; }
        public decimal Close { get; }
        public decimal Volume { get; }

        public CandleStick(DateTime openTime, decimal open, decimal high, decimal low, decimal close, decimal volume)
        {
            OpenTime = openTime;
            Open = open;
            High = high; 
            Low = low; 
            Close = close; 
            Volume = volume;
        }
    }

    [ApiController]
    [Route("candlestick")]
    public class CandleStickController : ControllerBase
    {
        private BinanceClient client = null;

        private void Setup()
        {
            if (client == null)
            {
                client = new BinanceClient();
                client.SetApiCredentials("X",
                    "Y");
            }
        }
        
        [HttpGet]
        [Route("ticker")]
        public IEnumerable<string> GetAllTickers()
        {
            Setup();

            return (client as IExchangeClient).GetTickersAsync()
                    .Result
                    .Data
                    .Select(x => x.CommonSymbol)
                    .Where(x => x.Contains("USDT"));
        }

        [HttpGet]
        [Route("klines")]
        public IEnumerable<CandleStick> GetTickerKlines(string symbol, int timespan, DateTime? startTime = null, DateTime? endTime = null, int? limit = null)
        {
            Setup();

            return (client as IExchangeClient).GetKlinesAsync(symbol, TimeSpan.FromMinutes(5), startTime, endTime)
                .Result
                .Data
                .Select(x => new CandleStick(x.CommonOpenTime, x.CommonOpen, x.CommonHigh, x.CommonLow, x.CommonClose, x.CommonVolume));
        }
    }
}
