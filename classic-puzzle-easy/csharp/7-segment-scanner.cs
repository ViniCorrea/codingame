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
        string line1 = Console.ReadLine();
        string line2 = Console.ReadLine();
        string line3 = Console.ReadLine();
        // Initialize an empty string to store the result
        string result = "";

        // Loop through the display
        for (int i = 0; i < line1.Length; i += 3)
        {
            // Taking 3 characters from each line
            string currentSegment = line1.Substring(i, 3) + line2.Substring(i, 3) + line3.Substring(i, 3);

            // Look up the currentSegment in segmentDict and append the corresponding digit to the result
            result += AsciiNumbers.SegmentDict[currentSegment];
        }

        Console.WriteLine(result);
    }
}

static class AsciiNumbers {
    public static Dictionary<string, char> SegmentDict => new Dictionary<string, char>
        {
            { " _ | ||_|", '0' },
            { "     |  |", '1' },
            { " _  _||_ ", '2' },
            { " _  _| _|", '3' },
            { "   |_|  |", '4' },
            { " _ |_  _|", '5' },
            { " _ |_ |_|", '6' },
            { " _   |  |", '7' },
            { " _ |_||_|", '8' },
            { " _ |_| _|", '9' }
        };
}