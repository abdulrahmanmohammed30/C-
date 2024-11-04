using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Win32;
using System;


namespace WindowsRegistory
{
    public class DeletingFromRegistry
    {
        public void Function()
        {
            string keyPath = @"HKEY_LOCAL_MACHINE\SOFTWARE\YUORSOFTWARE";
            string valueName = "YourName";

            try
            {
                using (var key = Registry.CurrentUser.OpenSubKey(keyPath, true))
                {
                    if (key == null)
                    {
                        Console.WriteLine("Value was deleted");
                    }
                    else
                    {
                        key.DeleteValue(valueName);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}