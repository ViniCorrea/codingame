using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        int N = int.Parse(Console.ReadLine());
        int[] strengths = new int[N];

        for (int i = 0; i < N; i++)
        {
            strengths[i] = int.Parse(Console.ReadLine());
        }

        Array.Sort(strengths);

        int minDiff = int.MaxValue;

        for (int i = 1; i < N; i++)
        {
            int diff = strengths[i] - strengths[i - 1];
            if (diff < minDiff)
            {
                minDiff = diff;
            }
        }

        Console.WriteLine(minDiff);
    }
}