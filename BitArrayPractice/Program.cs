// See https://aka.ms/new-console-template for more information
using System;
using System.Collections;
using System.Runtime.CompilerServices;



var bitArr = new BitArray(8);

bitArr.Set(0, true);
bitArr.Set(1, false);

foreach (var bit in bitArr) Console.WriteLine(bit);
// return from other solutons to improve thinking skills, coding skills, etc
// think about all possible cases or examples 
// avoid toy solutions which were implemented without tracing
// trace your solution with serveral examples 
// ask ai chatbots to provide you with more examples 
// save portions of code and return to it when needed such as cahe and -1 
// develop a procedure you walk into 
// always read others solutions and learn from to develop crucial 
public class Solution
{
    public int MinDistance(string word1, string word2)
    {
        int n = word1.Length;
        int m = word2.Length;


        int Solver(int i, int j)
        {
            if (i == n || j == m) return false;

            int count = int.MaxValue;

            if (word1[i] == word2[j]) count = Solver(i + 1, j + 1);
            else
            {
                // change 
                count = Math.Min(count, 1 + Solver(i + 1, j + 1));

                // skip in i 
                count = Math.Min(count, 1 + Solver(i + 1, j));

                // skip in j 
                count = Math.Min(count, 1 + Solver(i, j + 1));

            }

            return count;
        }
    }
}