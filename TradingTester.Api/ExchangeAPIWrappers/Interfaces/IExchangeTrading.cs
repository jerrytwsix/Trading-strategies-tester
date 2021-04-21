using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptoExchange.Net.ExchangeInterfaces;
using CryptoExchange.Net.Objects;

namespace TradingTester.Api.ExchangeAPIWrappers.ExchangeInterfaces
{
    public interface IExchangeTrading
    {
        public Task<WebCallResult<IEnumerable<ICommonBalance>>> GetBalancesAsync(string accountId);

    }
}
