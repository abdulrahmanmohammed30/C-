using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events
{

    public class StockEventArgs
    {
        public string StockSymbol { get; set; }
        public decimal Price { get; set; }

        public StockEventArgs(string stockSymbol, decimal price)
        {
            StockSymbol = stockSymbol;
            Price = price;
        }
    }


    public class StockMarket
    {
        private Dictionary<string, Action<StockEventArgs>> _subscribers = new();

        public void Subscribe(string stockSymbol, Action<StockEventArgs> handler)
        {
            if (!_subscribers.ContainsKey(stockSymbol))
                throw new Exception("Provide a valid stock name");

            if (!_subscribers[stockSymbol].GetInvocationList().Contains(handler))
            {
                _subscribers[stockSymbol] += handler;
                Console.WriteLine($"Handler was added successfully for {stockSymbol}");
            }
            else
                Console.WriteLine($"Handler is already exists for {stockSymbol}");
        }

        public void Unsubscribe(string stockSymbol, Action<StockEventArgs> handler)
        {
            if (!_subscribers.ContainsKey(stockSymbol))
                throw new Exception("Provide a valid stock name");

            if (!_subscribers[stockSymbol].GetInvocationList().Contains(handler))

                Console.WriteLine($"Handler is already not included in the subscriber list for {stockSymbol}");
            else
            {
                _subscribers[stockSymbol] -= handler;
                Console.WriteLine($"hanlder was removed successfully for {stockSymbol}");
            }
        }

        public void AddNewStockSymbolEvent(string stockSymbol)
        {
            _subscribers[stockSymbol] = delegate { };
        }

        public void UpdateStockPrice(string stockSymbol, decimal price)
        {
            if (!_subscribers.ContainsKey(stockSymbol))
            {
                AddNewStockSymbolEvent(stockSymbol);
                return;
            }
            _subscribers[stockSymbol]?.Invoke(new StockEventArgs(stockSymbol, price));
        }
    }


    public class IndividualInvestor
    {
        private string _name;

        public IndividualInvestor(string name)
        {
            _name = name;
        }

        public void OnStockPriceChanged(StockEventArgs e)
        {
            Console.WriteLine($"{_name} notified: New price for {e.StockSymbol} is {e.Price:C}");
        }
    }

    public class TradingBot
    {
        private string _botName;

        public TradingBot(string botName)
        {
            _botName = botName;
        }

        public void OnStockPriceChanged(StockEventArgs e)
        {
            Console.WriteLine($"{_botName} executing trade on {e.StockSymbol} at {e.Price:C}");
        }
    }
}