import React from 'react'
import Plot from 'react-plotly.js';



class Stock extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      stockChartXValues: [],
      stockChartYValuesclose: [],
      stockChartYValueshigh: [],
      stockChartYValueslow: [],
      stockChartYValuesopen: [],
      value: 'AAPL',
      time: '5min',
    }
    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }


  handleChange(event) {
    if (event.target.name === "timeframe") {
      this.setState({ time: event.target.value });
    } else if (event.target.name === "start") {
      this.setState({ startdate: event.target.value });
    } else if (event.target.name === "end") {
      this.setState({ enddate: event.target.value });
    }
    else
      this.setState({ value: event.target.value });
  }


  handleSubmit(event) {
    const pointerToThis = this;
    console.log(pointerToThis);
    const API_KEY = '8FGEIG1UKRHEHI01';
    //let StockSymbol = 'BTCUSDT';
    let StockSymbol = this.state.value;
    let timeFrame = this.state.time;

    //let API_Call = `https://www.alphavantage.co/query?function=TIME_SERIES_DAILY_ADJUSTED&symbol=${StockSymbol}&outputsize=full&apikey=${API_KEY}`;
    let API_Call = `https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol=${StockSymbol}&interval=${timeFrame}&apikey=${API_KEY}`
    let stockChartXValuesFunction = [];
    let stockChartYValuesFunctionclose = [];
    let stockChartYValuesFunctionhigh = [];
    let stockChartYValuesFunctionlow = [];
    let stockChartYValuesFunctionopen = [];

    fetch(API_Call)
      .then(
        function (response) {
          return response.json();
        }
      )
      .then(
        function (data) {

          for (var key in data[`Time Series (${timeFrame})`]) {
            stockChartXValuesFunction.push(key);
            stockChartYValuesFunctionopen.push(data[`Time Series (${timeFrame})`][key]['1. open']);
            stockChartYValuesFunctionhigh.push(data[`Time Series (${timeFrame})`][key]['2. high']);
            stockChartYValuesFunctionlow.push(data[`Time Series (${timeFrame})`][key]['3. low']);
            stockChartYValuesFunctionclose.push(data[`Time Series (${timeFrame})`][key]['4. close']);
          }

          //console.log(stockChartYValuesFunction);
          pointerToThis.setState({
            stockChartXValues: stockChartXValuesFunction,
            stockChartYValuesclose: stockChartYValuesFunctionclose,
            stockChartYValueshigh: stockChartYValuesFunctionhigh,
            stockChartYValueslow: stockChartYValuesFunctionlow,
            stockChartYValuesopen: stockChartYValuesFunctionopen
          });
        }
      )
    event.preventDefault();
  }

  render() {
    return (
      <div>
        <h1 className="content__title">Candlestick plot of {this.state.value}</h1>
        <form onSubmit={this.handleSubmit}>
          <input name="pair" onChange={this.handleChange} value={this.state.value} />
          <button>
            Submit
          </button>
        </form>

        <form onSubmit={this.handleSubmit}>
          <label>
            Select a time:
            <select name="timeframe" time={this.state.time} onChange={this.handleChange}>
              <option time="5min">5min</option>
              <option time="15min">15min</option>
              <option time="30min">30min</option>
              <option time="60min">60min</option>
            </select>
          </label>
          <input type="Submit" value="Choose" />
        </form>

        <input onChange={this.handleChange} type="date" name="start" startdate=""></input>
        <input onChange={this.handleChange} type="date" name="end" enddate=""></input>

        <Plot
          data={[
            {
              x: this.state.stockChartXValues,
              open: this.state.stockChartYValuesopen,
              high: this.state.stockChartYValueshigh,
              low: this.state.stockChartYValueslow,
              close: this.state.stockChartYValuesclose,
              //y: this.state.stockChartYValuesopen,
              type: 'candlestick',
            }
          ]}
          layout={{ width: 1000, height: 440 }}
        />
      </div>
    )
  }
}

export default Stock;