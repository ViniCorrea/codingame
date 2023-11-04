#!/bin/bash

# Read the number of input and output signals
read -r number_of_inputs
read -r number_of_outputs

declare -A input_signals

# Read input signals
for ((i=0; i<number_of_inputs; i++)); do
  read -r input_name input_signal
  # Replace '-' with '1' and '_' with '0'
  input_signals["$input_name"]=$(sed 's/-/1/g; s/_/0/g' <<< "$input_signal")
done

# Function to perform a logical gate operation
gate_operation() {
  local op=$1
  local sig1=$2
  local sig2=$3
  local result=""

  for ((i=0; i<${#sig1}; i++)); do # ${#variable} is used to get the length of the value 
    local bit1=${sig1:$i:1}
    local bit2=${sig2:$i:1}
    local res_bit

    # Perform the operation based on the type
    case "$op" in
      "AND") res_bit=$((bit1 & bit2)) ;;
      "OR") res_bit=$((bit1 | bit2)) ;;
      "XOR") res_bit=$((bit1 ^ bit2)) ;;
      "NAND") res_bit=$(((bit1 & bit2) ^ 1)) ;;
      "NOR") res_bit=$(((bit1 | bit2) ^ 1)) ;;
      "NXOR") res_bit=$(((bit1 ^ bit2) ^ 1)) ;;
      *) echo "Unknown: $op" >&2; exit 1 ;;
    esac

    # Append the result bit to the result string
    result+=$res_bit
  done

  # Replace '1' with '-' and '0' with '_' for output
  echo "$result" | sed 's/1/-/g; s/0/_/g'
}

# Process the outputs
for ((i=0; i<number_of_outputs; i++)); do
  read -r output_name gate_type input_name1 input_name2
  signal1=${input_signals["$input_name1"]}
  signal2=${input_signals["$input_name2"]}

  # Calculate the output signal
  output_signal=$(gate_operation "$gate_type" "$signal1" "$signal2")

  # Output the result
  echo "$output_name $output_signal"
done
