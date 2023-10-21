using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine()); // the number of temperatures to analyse
        string[] inputs = Console.ReadLine().Split(' ');
        
        var tempClosestZero = int.MaxValue;
        for (int i = 0; i < n; i++)
        {
            int t = int.Parse(inputs[i]);// a temperature expressed as an integer ranging from -273 to 5526
            tempClosestZero = Closest(t, tempClosestZero);
        }

        Console.WriteLine(tempClosestZero == int.MaxValue ? 0 : tempClosestZero);
    }

    public static int Closest(int x, int y)
    {
        int absX = Math.Abs(x);
        int absY = Math.Abs(y);

        return absX < absY ? x :
            absX > absY ? y :
            absX == absY ? Math.Max(x, y) :
            x;
    }

}