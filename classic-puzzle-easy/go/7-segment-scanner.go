package main

import (
	"fmt"
)

func main() {
	line1 := " _     _  _     _  _  _  _  _ "
	line2 := "| |  | _| _||_||_ |_   ||_||_|"
	line3 := "|_|  ||_  _|  | _||_|  ||_| _|"

	result := ""

	for i := 0; i < len(line1); i += 3 {
		currentSegment := line1[i:i+3] + line2[i:i+3] + line3[i:i+3]
		number := matchSegment(currentSegment)
		result += string(number)
	}

	fmt.Println(result)
}

func matchSegment(currentSegment string) byte { //more memory-efficient and faster when performing equality checks and other character-related operations.
	for i, segment := range []string{
		" _ | ||_|", // 0
		"     |  |", // 1
		" _  _||_ ", // 2
		" _  _| _|", // 3
		"   |_|  |", // 4
		" _ |_  _|", // 5
		" _ |_ |_|", // 6
		" _   |  |", // 7
		" _ |_||_|", // 8
		" _ |_| _|", // 9
	} {
		if segment == currentSegment {
			return byte('0' + i)
		}
	}
	return 'X' // Return 'X' for unknown segments
}
