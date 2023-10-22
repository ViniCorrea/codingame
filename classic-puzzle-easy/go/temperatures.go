package main

import "fmt"
import "os"
import "bufio"
import "strings"
import "strconv"
import "math"


func main() {
    scanner := bufio.NewScanner(os.Stdin)
    scanner.Buffer(make([]byte, 1000000), 1000000)
    var inputs [] string

    // n: the number of temperatures to analyse
    var n int = 3
    //scanner.Scan()
    //fmt.Sscan(scanner.Text(),&n)
    
    //scanner.Scan()
    //inputs = strings.Split(scanner.Text()," ")
	inputs = strings.Split("-12 -5 -137", " ")

	var tempClosestZero float64 = math.MaxFloat64
    for i := 0; i < n; i++ {
        // t: a temperature expressed as an integer ranging from -273 to 5526
        t,_ := strconv.ParseInt(inputs[i],10,32)
        tempClosestZero = closest(float64(t), tempClosestZero)
    }
    
	// Go does not have a ternary operator
	//Console.WriteLine(tempClosestZero == int.MaxValue ? 0 : tempClosestZero);
	if tempClosestZero == math.MaxFloat64 {
		fmt.Println(0)
	} else {
		fmt.Println(tempClosestZero)
	}
}

func closest(x, y float64) float64 {
	var absX float64 = math.Abs(x) // Math Abs definition: func Abs(x float64) float64
	var absY float64 = math.Abs(y)
	
    if absX < absY {
        return x
    } else if absX > absY {
        return y
    } else if absX == absY {
        return math.Max(x, y)
    } else {
        return x
    }
}