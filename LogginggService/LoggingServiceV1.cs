using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LogginggService
{
    using System;
    using System.Transactions;

    public class LoggingService
    {
        public void Log(string message, Action<string> LoggingHandler)
        {

            LoggingHandler(message);
        }

    }

    public class DatabaseLoggingService
    {
        public void Log(string message)
        {
            Console.WriteLine($"\nLog to Database: {message}");
        }
    }

    class FileLoggingService
    {
        public void Log(string message)
        {
            Console.WriteLine($"\nLog to file: {message}");
        }

    }

    class EventLoggingService
    {
        public void Log(string message)
        {

            Console.WriteLine($"\nLog to Event Log: {message}");
        }

    }



    // class Program
    // {
    //     static void Main()
    //     {
    //         // Create an instance of the LoggingService
    //         var LoggingService = new LoggingService();

    //         // No need to define instances 
    //         // because the classes are doing the same logic regardless 
    //         // using a static method will be more better 
    //         // var fileLoggingService = new FileLoggingService();
    //         // var eventLoggingService = new EventLoggingService();
    //         // var databaseLoggingService = new DatabaseLoggingService();

    //         // Log to File
    //         // LoggingService.Log("Error Occured line xxx.", fileLoggingService.Log);

    //         // // Log to Event Log
    //         // LoggingService.Log("Error Occured line xxx.", eventLoggingService.Log);

    //         // // Log to Database
    //         // LoggingService.Log("Error Occured line xxx.", databaseLoggingService.Log);

    //         Console.ReadKey();

    //     }
    // }

}