using Microsoft.Win32;
using System.Configuration;
using System.Diagnostics;
using System.Text;

namespace Website
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ConfigurationManager.AppSettings["AppName"]);
            Console.WriteLine(ConfigurationManager.ConnectionStrings["SqlServerConnection"]);
            Console.Write(ConfigurationManager.ConnectionStrings["SqlServerWithTimeout"]);


            const string appName = "GScraper";

            if (!EventLog.SourceExists(appName))
            {
                EventLog.CreateEventSource(appName, "Application");
                Console.WriteLine("Source was created successfully");
            }

            EventLog.WriteEntry(appName, "App failed unexpectedly", EventLogEntryType.Error);

            foreach(var i in Encoding.UTF8.GetBytes(appName))
            Console.WriteLine(i);



            Console.ReadLine();

        }

    }
}
