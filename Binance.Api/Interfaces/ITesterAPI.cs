using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CryptoExchange.Net.Objects;
using CryptoExchange.Net.ExchangeInterfaces;
using CryptoExchange.Net.Authentication;
using CryptoExchange.Net.Logging;
using CryptoExchange.Net;

namespace TradingTester.Api
{
    public interface ITesterAPI
    {
        public void SetApiCredentials(string apiKey, string apiSecret);
        //async Task<WebCallResult<ICommonTicker>> IExchangeClient.GetTickerAsync(string symbol);
    }
}