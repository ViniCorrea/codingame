import sys
import math

n = int(input())
m = int(input())

# Define gate operations
gate_operations = {
    'AND': lambda b1, b2: b1 and b2,
    'OR': lambda b1, b2: b1 or b2,
    'XOR': lambda b1, b2: b1 ^ b2,
    'NAND': lambda b1, b2: not (b1 and b2),
    'NOR': lambda b1, b2: not (b1 or b2),
    'NXOR': lambda b1, b2: not (b1 ^ b2)
}

# Read input signals
input_signals = {}
for i in range(n):
    input_name, input_signal = input().split()
    input_signals[input_name] = [x == '-' for x in input_signal]

# Read output specifications and compute results
outputs = []
for _ in range(m):
    output_name, gate_type, input_name_1, input_name_2 = input().split()
    signal1 = input_signals[input_name_1]
    signal2 = input_signals[input_name_2]
    output_signal = [gate_operations[gate_type](b1, b2) for b1, b2 in zip(signal1, signal2)]
    output_signal_str = ''.join('-' if bit else '_' for bit in output_signal)
    outputs.append(f"{output_name} {output_signal_str}")

# Print the outputs
for output in outputs:
    print(output)
