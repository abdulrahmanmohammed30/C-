using System;
using System.Transactions;
// using Exmaple2;
//using Example3;

// public class LoggingService
// {
//     private ILogger _Notification;
//     public LoggingService(ILogger Notification)
//     {
//         _Notification = Notification;
//     }
//     public void Log(string message)
//     {
//         _Notification.Log(message);
//     }

// }
// public interface ILogger
// {
//     public void Log(string message);
// }

// public class DatabaseLoggingService : ILogger
// {
//     public void Log(string message)
//     {
//         Console.WriteLine($"\nLog to Database: {message}");
//     }
// }

// class FileLoggingService : ILogger
// {
//     public void Log(string message)
//     {
//         Console.WriteLine($"\nLog to file: {message}");
//     }

// }

// class EventLoggingService : ILogger
// {
//     public void Log(string message)
//     {

//         Console.WriteLine($"\nLog to Event Log: {message}");
//     }

// }



class Program
{
    static void Main()
    {
        // No need to define instances 
        // because the classes are doing the same logic regardless 
        // var fileLoggingService = new LoggingService(new FileLoggingService());
        // var eventLoggingService = new LoggingService(new EventLoggingService());
        // var databaseLoggingService = new LoggingService(new DatabaseLoggingService());

        // // Log to File
        // fileLoggingService.Log("Error Occured line xxx.");

        // // Log to Event Log
        // eventLoggingService.Log("Error Occured line xxx.");

        // // Log to Database
        // databaseLoggingService.Log("Error Occured line xxx.");

        // Console.ReadKey();

        // var reportGenerator = new ReportGenerator(new PDFReportGenerator());
        // reportGenerator.GenerateReport("reprot3");

        // reportGenerator = new ReportGenerator(new CSVReportGenerator());
        // reportGenerator.GenerateReport("reprot5");

        // Create an instance of the LoggingService
        // LoggingService LoggingService = new LoggingService(new FileLoggingService());
        // // Log to File
        // LoggingService.Log("Error Occured line xxx.");

        // LoggingService = new LoggingService(new EventLogService());
        // // Log to Event Log
        // LoggingService.Log("Error Occured line xxx.");

        // LoggingService = new LoggingService(new DatabaseLoggingService());
        // // Log to Database
        // LoggingService.Log("Error Occured line xxx.");


        // Console.ReadKey();

    }
}
