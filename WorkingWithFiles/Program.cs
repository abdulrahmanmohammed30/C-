
using System.Xml.Serialization;
using System.Xml;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;
using System.Text;


// string name = "name30";
// using (var file = new FileStream("name.txt", FileMode.Create))
// {
//     file.Write(Encoding.UTF8.GetBytes(name));
// }

// using (var file = new FileStream("name.txt", FileMode.Open))
// {
//     int? b;
//     while ((b=file.ReadByte()) != -1))
//     {
//         if (b < 0 || b > 255) continue;
//         char ch = (char)b;
//         Console.WriteLine(ch);
//     }
// }



// string name = "name30";
// using (var writer = new StreamWriter("name.txt"))
// {
//     writer.WriteLine(name);
// }

// using (var reader = new StreamReader("name.txt"))
// {
//     // int? b;
//     // while ((b = reader.Read()) != -1)
//     // {
//     //     if (b < 0 || b > 255) continue;
//     //     char ch = (char)b;
//     //     Console.WriteLine(b);
//     // }
//     Console.WriteLine(reader.ReadToEnd());
// }


// int[] arr = { 1, 2, 3, 4, 5, 6 };

// using (var writer = new StreamWriter("numbers.txt"))
// {
//     foreach (var i in arr)
//         writer.WriteLine(i);
// }
// using (var reader = new StreamReader("numbers.txt"))
// {

//     Console.WriteLine(reader.ReadToEnd());
// }