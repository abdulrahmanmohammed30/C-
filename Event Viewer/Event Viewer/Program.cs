using System;
using System.Diagnostics;
/* 
    you have to specify the application name for the log regardless of
    it was an error, warning or information 

    open vscode as administrator -> need permissions 
    download the package using Nuget 

*/

// specify the source name for the evnet log - source means your applicastion name 
string sourceName = "Esno";

// Create the event if does not exist 
if (!EventLog.SourceExists(sourceName))
{
    EventLog.CreateEventSource(sourceName, "Application");
    Console.WriteLine("Event source created.");
}

// Log an Information event 
EventLog.WriteEntry(sourceName, "Information to be written to Entry", EventLogEntryType.Information);


// Log a Warning event 
EventLog.WriteEntry(sourceName, "Warning to be written to Entry", EventLogEntryType.Warning);


// Log an Error event 
EventLog.WriteEntry(sourceName, "Error to be written to Entry", EventLogEntryType.Error);
