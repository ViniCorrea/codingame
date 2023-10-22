package main

import "fmt"

type Thor struct {
	GoTo string
	X    int
	Y    int
}

func main() {
    // lightX: the X position of the light of power
    // lightY: the Y position of the light of power
    // initialTx: Thor's starting X position
    // initialTy: Thor's starting Y position
    var lightX, lightY, initialTx, initialTy int
    fmt.Scan(&lightX, &lightY, &initialTx, &initialTy)
    thor := Thor{X: initialTx, Y: initialTy}
    for {
        // remainingTurns: The remaining amount of turns Thor can move. Do not remove this line.
        var remainingTurns int
        fmt.Scan(&remainingTurns)
        
        
		walkToLight(&thor, lightX, lightY) // pointer semantics are used to mutate the value of a struct. So the walkToLight function accepts a pointer to a Thor object.
		fmt.Println(thor.GoTo)
    }
}

func walkToLight(thor *Thor, lightX int, lightY int) {
	switch {
		case thor.X < lightX && thor.Y == lightY:
			thor.GoTo = "E"
			thor.X++
		case thor.X > lightX && thor.Y == lightY:
			thor.GoTo = "W"
			thor.X--
		case thor.X == lightX && thor.Y < lightY:
			thor.GoTo = "S"
			thor.Y++
		case thor.X > lightX && thor.Y < lightY:
			thor.GoTo = "SW"
			thor.X--
			thor.Y++
		case thor.X < lightX && thor.Y < lightY:
			thor.GoTo = "SE"
			thor.X++
			thor.Y++
		case thor.X == lightX && thor.Y > lightY:
			thor.GoTo = "N"
			thor.Y--
		case thor.X < lightX && thor.Y > lightY:
			thor.GoTo = "NE"
			thor.X++
			thor.Y--
		case thor.X > lightX && thor.Y > lightY:
			thor.GoTo = "NW"
			thor.X--
			thor.Y--
		default:
			thor.GoTo = " "
	}
}