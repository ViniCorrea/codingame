using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Player
{
    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        int lightX = int.Parse(inputs[0]); // the X position of the light of power
        int lightY = int.Parse(inputs[1]); // the Y position of the light of power
        int initialTx = int.Parse(inputs[2]); // Thor's starting X position
        int initialTy = int.Parse(inputs[3]); // Thor's starting Y position

        var actualTPosition = new Tuple<int, int>(initialTx, initialTy);

        // game loop
        while (true)
        {
            int actualTx = int.Parse(inputs[2]); // Thor's X position
            int actualTY = int.Parse(inputs[3]); // Thor's Y position
            int remainingTurns = int.Parse(Console.ReadLine()); // The remaining amount of turns Thor can move. Do not remove this line.

            actualTPosition = WalkToLight(actualTPosition, lightX, lightY);
        }
    }

    static Tuple<int, int> WalkToLight(Tuple<int, int> actualPosition, int lightX, int lightY){
            if (actualPosition.Item2 == lightY && actualPosition.Item1 < lightX) {
                Console.WriteLine("E");
                return new Tuple<int, int>(actualPosition.Item1 + 1, actualPosition.Item2);
            } else if (actualPosition.Item2 == lightY && actualPosition.Item1 > lightX) {
                Console.WriteLine("W");
                return new Tuple<int, int>(actualPosition.Item1 - 1, actualPosition.Item2);
            } else if (actualPosition.Item1 == lightX && actualPosition.Item2 < lightY) {
                Console.WriteLine("S");
                return new Tuple<int, int>(actualPosition.Item1, actualPosition.Item2 + 1);
            } else if (actualPosition.Item1 > lightX && actualPosition.Item2 < lightY) {
                Console.WriteLine("SW");
                return new Tuple<int, int>(actualPosition.Item1 - 1, actualPosition.Item2 + 1);
            } else if (actualPosition.Item1 < lightX && actualPosition.Item2 < lightY) {
                Console.WriteLine("SE");
                return new Tuple<int, int>(actualPosition.Item1 + 1, actualPosition.Item2 + 1);
            } else if (actualPosition.Item1 == lightX && actualPosition.Item2 > lightY) {
                Console.WriteLine("N");
                return new Tuple<int, int>(actualPosition.Item1, actualPosition.Item2 - 1);
            } else if (actualPosition.Item1 < lightX && actualPosition.Item2 > lightY) {
                Console.WriteLine("NE");
                return new Tuple<int, int>(actualPosition.Item1 - 1, actualPosition.Item2 + 1);
            } else if (actualPosition.Item1 > lightX && actualPosition.Item2 > lightY) {
                Console.WriteLine("NW");
                return new Tuple<int, int>(actualPosition.Item1 + 1, actualPosition.Item2 + 1);
            }

            return new Tuple<int, int>(actualPosition.Item1, actualPosition.Item2);
    }
}