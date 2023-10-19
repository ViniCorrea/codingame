package main

import (
	"fmt"
	"math"
	"sort"
)

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/

func main() {
	var N int
	fmt.Scan(&N)

	strengths := make([]int, N)

	for i := 0; i < N; i++ {
		fmt.Scanln(&strengths[i])
	}

	sort.Ints(strengths)
	minDiff := math.MaxInt32

	for i := 1; i < N; i++ {
		diff := strengths[i] - strengths[i-1]
		if diff < minDiff {
			minDiff = diff
		}
	}

	fmt.Println(minDiff)
}
