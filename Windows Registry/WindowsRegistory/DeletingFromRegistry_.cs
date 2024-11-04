using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace WindowsRegistory
{
    public class DeletingFromRegistry_
    {
        public void Function()
        {

            string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\YUORSOFTWARE";
            string valueName = "YourName";

            using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
            {
                using (var key = baseKey.OpenSubKey(keyPath, true))
                {
                    if (key == null)
                    {
                        Console.WriteLine($"Registry key '{keyPath}' not found");
                    }
                    else
                    {
                        key.DeleteValue(valueName);
                        Console.WriteLine($"Successfully deleted value '{valueName}' from registry key '{keyPath}'");
                    }
                }
            }
        }
    }
}