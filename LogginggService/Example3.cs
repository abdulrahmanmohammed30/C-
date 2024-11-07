using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Transactions;


namespace Example3
{
    //this code is not OCP compliant, modify it to be compliant.
    public class LoggingService
    {
        public ILogger _Logger;
        public LoggingService(ILogger Logger)
        {
            _Logger = Logger;
        }
        public void Log(string message)
        {
            _Logger.Log(message);
        }

    }
    public interface ILogger
    {
        public void Log(string message);
    }
    public class FileLoggingService : ILogger
    {
        // Method to log to file
        public void Log(string message)
        {
            Console.WriteLine($"\nLog to file: {message}");
        }
    }

    public class EventLogService : ILogger
    {
        // Method to log to EventLog
        public void Log(string message)
        {
            Console.WriteLine($"\nLog to Event Log: {message}");
        }
    }

    public class DatabaseLoggingService : ILogger
    {

        // Method to log to file
        public void Log(string message)
        {
            Console.WriteLine($"\nLog to Database: {message}");
        }
    }


    // class Program
    // {
    //     static void Main()
    //     {
    //         // Create an instance of the LoggingService
    //         LoggingService LoggingService = new LoggingService(new FileLoggingService());
    //         // Log to File
    //         LoggingService.Log("Error Occured line xxx.");

    //         LoggingService = new LoggingService(new EventLogService());
    //         // Log to Event Log
    //         LoggingService.Log("Error Occured line xxx.");

    //         LoggingService = new LoggingService(new DatabaseLoggingService());
    //         // Log to Database
    //         LoggingService.Log("Error Occured line xxx.");


    //         Console.ReadKey();
    //     }
    //}

}