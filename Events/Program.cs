using System;
using System.Runtime.CompilerServices;

namespace Events
{
    public class Program
    {
        public static void Example1()
        {
            var thermostat = new Thermostat();
            var cooler = new Cooler(50);
            var heater = new Heater(30);

            thermostat.TemperatureChanged += cooler.OnTemperatureChanged;
            thermostat.TemperatureChanged += heater.OnTemperatureChanged;
            thermostat.Temperature = 55.3;
        }
        public static void Example2()
        {
            User user = new User("John Doe", "123-45-6789");

            BankAccount account = new BankAccount(user, "123456789", 3000);

            var federalAgency = new FederalAgency();
            account.UserBalanceExceeded += federalAgency.InvestigateUserIncomeSources;

            // The event 'Program.BankAccount.UserBalanceExceeded' can only appear on the left hand side of += or -= 
            // (except when used from within the type 'Program.BankAccount')
            //account.UserBalanceExceeded.Invoke(User); 

            //The event 'Program.BankAccount.UserBalanceExceeded' can only appear on the left hand side of += or -= 
            // (except when used from within the type 'Program.BankAccount')
            // account.UserBalanceExceeded = federalAgency.InvestigateUserIncomeSources;

            account.Deposit(6000000);
        }

        public static void Print()
        {
            Console.WriteLine("Print");
        }
        public static void Example3()
        {
            var newsPublisher = new NewsPublisher();
            var newsAggregator = new NewsAggregator();
            var newsReader = new NewsReader("newsReader");

            newsPublisher.AddEventHandlerFor("Learning");
            newsPublisher.AddEventHandlerFor("English");

            newsPublisher.Subscribe("Learning", newsAggregator.OnNewsReceived);
            newsPublisher.Subscribe("English", newsReader.OnNewsReceived);

            newsPublisher.Subscribe("English", newsReader.OnNewsReceived);


            newsPublisher.PublishNews("Learning", "New Learning title", "New content");
            newsPublisher.PublishNews("English", "New English title", "New English content");

        }
        public static void Example4()
        {
            var stockMarket = new StockMarket();
            stockMarket.AddNewStockSymbolEvent("AAPL");
            stockMarket.AddNewStockSymbolEvent("GOOGL");

            var individualInvestor = new IndividualInvestor("invester30");
            stockMarket.Subscribe("AAPL", individualInvestor.OnStockPriceChanged);

            var tradingBot = new TradingBot("tradingbot30");
            stockMarket.Subscribe("GOOGL", tradingBot.OnStockPriceChanged);


            stockMarket.UpdateStockPrice("AAPL", 300);
            stockMarket.UpdateStockPrice("GOOGL", 450);
            stockMarket.UpdateStockPrice("AAPL", 800);
        }
        public static void Main()
        {
            //Example1();
            //Example2();
            //Example3();
            Example4();
            // Console.WriteLine(new Random().NextDouble());
            // Console.WriteLine(new Random().Next(2));
        }

    }
}
