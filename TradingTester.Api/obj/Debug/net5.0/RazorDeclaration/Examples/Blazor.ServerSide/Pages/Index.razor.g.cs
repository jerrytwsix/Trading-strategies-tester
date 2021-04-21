// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace TradingTester.Api.Examples.Blazor_ServerSide.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\ThingsForWork\Trading-strategies-tester\TradingTester.Api\Examples\Blazor.ServerSide\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\ThingsForWork\Trading-strategies-tester\TradingTester.Api\Examples\Blazor.ServerSide\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\ThingsForWork\Trading-strategies-tester\TradingTester.Api\Examples\Blazor.ServerSide\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\ThingsForWork\Trading-strategies-tester\TradingTester.Api\Examples\Blazor.ServerSide\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\ThingsForWork\Trading-strategies-tester\TradingTester.Api\Examples\Blazor.ServerSide\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\ThingsForWork\Trading-strategies-tester\TradingTester.Api\Examples\Blazor.ServerSide\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\ThingsForWork\Trading-strategies-tester\TradingTester.Api\Examples\Blazor.ServerSide\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\ThingsForWork\Trading-strategies-tester\TradingTester.Api\Examples\Blazor.ServerSide\_Imports.razor"
using Blazor.ServerSide;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\ThingsForWork\Trading-strategies-tester\TradingTester.Api\Examples\Blazor.ServerSide\_Imports.razor"
using Blazor.ServerSide.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\ThingsForWork\Trading-strategies-tester\TradingTester.Api\Examples\Blazor.ServerSide\Pages\Index.razor"
using Binance.Net.Interfaces;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\ThingsForWork\Trading-strategies-tester\TradingTester.Api\Examples\Blazor.ServerSide\Pages\Index.razor"
using Blazor.DataProvider;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\ThingsForWork\Trading-strategies-tester\TradingTester.Api\Examples\Blazor.ServerSide\Pages\Index.razor"
using CryptoExchange.Net.Sockets;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase, IAsyncDisposable
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 18 "C:\ThingsForWork\Trading-strategies-tester\TradingTester.Api\Examples\Blazor.ServerSide\Pages\Index.razor"
 
    private IEnumerable<IBinanceTick> _ticks = new List<IBinanceTick>();
    private UpdateSubscription _subscription;

    protected override async Task OnInitializedAsync()
    {
        var callResult = await _dataProvider.Get24HPrices();
        if (callResult)
            _ticks = callResult.Data;

        var subResult = await _dataProvider.SubscribeTickerUpdates(HandleTickUpdates);
        if (subResult)
            _subscription = subResult.Data;
    }

    private void HandleTickUpdates(IEnumerable<IBinanceTick> ticks)
    {
        foreach (var tick in ticks)
        {
            var symbol = _ticks.Single(t => t.Symbol == tick.Symbol);
            symbol.PriceChangePercent = tick.PriceChangePercent;
        }

        InvokeAsync(StateHasChanged);
    }

    public async ValueTask DisposeAsync()
    {
        await _dataProvider.Unsubscribe(_subscription);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private BinanceDataProvider _dataProvider { get; set; }
    }
}
#pragma warning restore 1591
