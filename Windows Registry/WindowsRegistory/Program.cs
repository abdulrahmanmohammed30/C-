
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Win32;

string keyPath = @"HKEY_CURRENT_USER\SOFTWARE\Warrior";
var DarkMode = "DarkMode";


// Write a value 
// try {
//    Registry.SetValue(keyPath, DarkMode,"enabled", RegistryValueKind.String);
//    Console.WriteLine("DarkMode was enabled");
// }
// catch(Exception ex) {
//     Console.WriteLine(ex.Message);
// }

// Delete a value 
// try
// {
//     using (var key = Registry.CurrentUser.OpenSubKey(keyPath, true))
//     {
//         if (key == null)
//         {
//             Console.WriteLine($"Cannot delete value {DarkMode} User doesn't exist");
//         }
//         else
//         {
//             key.DeleteValue(DarkMode);
//         }
//     }
// }
// catch (Exception ex)
// {
//     Console.WriteLine(ex.Message);
// }

// try
// {
//     using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64))
//     {
//         using (var key = baseKey.OpenSubKey(keyPath, true))
//         {
//             if (key == null)
//             {
//                 Console.WriteLine($"Cannot delete value {DarkMode} User doesn't exist");
//             }
//             else
//             {
//                 key.DeleteValue(DarkMode);
//             }
//         }
//     }
// }
// catch (Exception ex)
// {
//     Console.WriteLine(ex.Message);
// }

Console.WriteLine(new Solution().ShoppingOffers([2, 9], [[1, 1, 10], [2, 2, 15], [3, 0, 5], [0, 3, 20]]
, [5, 5]
));
