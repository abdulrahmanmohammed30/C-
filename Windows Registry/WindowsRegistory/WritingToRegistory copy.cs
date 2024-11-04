using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Win32;


namespace WindowsRegistory
{
    public class WritingToRegistoryLocal
    {
        public void Function()
        {
            // specify the Registory key and path 

            // two ways to avoid permissin denied error 
            // run your program as an administrator: Run visual studio as administrator 
            string keyPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\YUORSOFTWARE";
            string valudName = "YourName";
            string valueData = "YourValueData";

            // have to do exception handling when dealing with registory 
            //numerious exceptions happens 
            try
            {
                // write to the Registory
                Registry.SetValue(keyPath, valudName, valueData, RegistryValueKind.String);

                Console.WriteLine("ValueName");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}