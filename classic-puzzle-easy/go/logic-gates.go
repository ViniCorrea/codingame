package main

import (
	"fmt"
	"strings"
)

func main() {
	var n int
	fmt.Scan(&n)

	var m int
	fmt.Scan(&m)

	inputSignals := make(map[string]string) // Dictionary
	for i := 0; i < n; i++ {
		var inputName, inputSignal string
		fmt.Scan(&inputName, &inputSignal)
		inputSignals[inputName] = inputSignal
	}

	gateOperations := map[string]func(bool, bool) bool{
		"AND":  func(b1, b2 bool) bool { return b1 && b2 },
		"OR":   func(b1, b2 bool) bool { return b1 || b2 },
		"XOR":  func(b1, b2 bool) bool { return b1 != b2 },
		"NAND": func(b1, b2 bool) bool { return !(b1 && b2) },
		"NOR":  func(b1, b2 bool) bool { return !(b1 || b2) },
		"NXOR": func(b1, b2 bool) bool { return b1 == b2 },
	}

	outputs := make([]string, m)
	for i := 0; i < m; i++ {
		var outputName, gateType, inputName1, inputName2 string
		fmt.Scan(&outputName, &gateType, &inputName1, &inputName2)

		signal1 := inputSignals[inputName1]
		signal2 := inputSignals[inputName2]
		var outputSignal strings.Builder

		for j := range signal1 {
			b1 := signal1[j] == '-'
			b2 := signal2[j] == '-'

			if gateOperations[gateType](b1, b2) {
				outputSignal.WriteRune('-')
			} else {
				outputSignal.WriteRune('_')
			}
		}

		outputs[i] = fmt.Sprintf("%s %s", outputName, outputSignal.String())
	}

	for _, output := range outputs {
		fmt.Println(output)
	}
}
