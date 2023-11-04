using System;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());

        Dictionary<string, string> inputSignals = new Dictionary<string, string>();
        List<Tuple<string, string, string, string>> outputSpecifications = new List<Tuple<string, string, string, string>>();
        List<string> outputResults = new List<string>();

        // Read input signals
        for (int i = 0; i < n; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            string inputName = inputs[0];
            string inputSignal = inputs[1];
            inputSignals[inputName] = inputSignal;
        }

        // Read output specifications
        for (int i = 0; i < m; i++)
        {
            string[] inputs = Console.ReadLine().Split(' ');
            string outputName = inputs[0];
            string type = inputs[1];
            string inputName1 = inputs[2];
            string inputName2 = inputs[3];

            outputSpecifications.Add(Tuple.Create(outputName, type, inputName1, inputName2));
        }

        // Compute output signals
        foreach (var spec in outputSpecifications)
        {
            string outputSignal = ComputeOutputSignal(inputSignals[spec.Item3], inputSignals[spec.Item4], spec.Item2);
            outputResults.Add($"{spec.Item1} {outputSignal}");
        }

        // Print output signals
        foreach (var result in outputResults)
        {
            Console.WriteLine(result);
        }
    }

    // Method to compute output signal
    static string ComputeOutputSignal(string inputSignal1, string inputSignal2, string gateType)
    {
        var outputSignal = new char[inputSignal1.Length];
        for (int i = 0; i < inputSignal1.Length; i++)
        {
            bool signal1 = inputSignal1[i] == '-';
            bool signal2 = inputSignal2[i] == '-';
            bool output;

            switch (gateType)
            {
                case "AND":
                    output = signal1 & signal2;
                    break;
                case "OR":
                    output = signal1 | signal2;
                    break;
                case "XOR":
                    output = signal1 ^ signal2;
                    break;
                case "NAND":
                    output = !(signal1 & signal2);
                    break;
                case "NOR":
                    output = !(signal1 | signal2);
                    break;
                case "NXOR":
                    output = !(signal1 ^ signal2);
                    break;
                default:
                    throw new ArgumentException("Invalid gate type.");
            }

            outputSignal[i] = output ? '-' : '_';
        }
        return new string(outputSignal);
    }
}
