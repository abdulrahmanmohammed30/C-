using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Win32;


namespace WindowsRegistory
{
    public class WritingToRegistory
    {
        public void Function()
        {
            // specify the Registory key and path 

            // only current user will see the value, other users won't 
            // it's not sensible to store the username and password in the Local Machine 
            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\YUORSOFTWARE";
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
            catch
            {
                Console.WriteLine("An Error has occured");
            }

        }
    }
}