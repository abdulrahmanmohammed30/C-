// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Runtime.CompilerServices;



var bitArr = new BitArray(8);

bitArr.Set(0, true);
bitArr.Set(1, false);

foreach (var bit in bitArr) Console.WriteLine(bit);

