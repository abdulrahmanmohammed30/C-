
// void LogToScreen(string message)
// {
//     Console.WriteLine(message);
// }

// var ScreenLogger = new Logger(LogToScreen);
// ScreenLogger.Log("War");

// class Logger
// {
//     private Action<string> _loggerHandler;
//     public Logger(Action<string> loggerHandler)
//     {
//         _loggerHandler = loggerHandler;
//     }

//     public void Log(string message)
//     {
//         _loggerHandler(message);
//     }
// }



var p = new Person("name", 22, "address");
p.PrintInfo();