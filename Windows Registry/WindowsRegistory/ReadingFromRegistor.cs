using Microsoft.Win32;
using System;

namespace WindowsRegistory
{
    public class ReadingFromToRegistory
    {
        public void Function()
        {

            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\YUORSOFTWARE";
            string valudName = "YourName";

            // have to do exception handling when dealing with registory 
            //numerious exceptions happens 
            try
            {
                // write to the Registory
                var val = Registry.GetValue(keyPath, valudName, null) as string;

                if (val is not null)
                    Console.WriteLine(val);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}