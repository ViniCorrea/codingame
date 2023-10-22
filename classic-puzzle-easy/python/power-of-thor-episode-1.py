import sys
import math

class Thor:
    def __init__(self, x, y):
        self.go_to = ""
        self.x = x
        self.y = y

def walk_to_light(thor, light_x, light_y):
    if thor.x < light_x and thor.y == light_y:
        thor.go_to = "E"
        thor.x += 1
    elif thor.x > light_x and thor.y == light_y:
        thor.go_to = "W"
        thor.x -= 1
    elif thor.x == light_x and thor.y < light_y:
        thor.go_to = "S"
        thor.y += 1
    elif thor.x > light_x and thor.y < light_y:
        thor.go_to = "SW"
        thor.x -= 1
        thor.y += 1
    elif thor.x < light_x and thor.y < light_y:
        thor.go_to = "SE"
        thor.x += 1
        thor.y += 1
    elif thor.x == light_x and thor.y > light_y:
        thor.go_to = "N"
        thor.y -= 1
    elif thor.x < light_x and thor.y > light_y:
        thor.go_to = "NE"
        thor.x += 1
        thor.y -= 1
    elif thor.x > light_x and thor.y > light_y:
        thor.go_to = "NW"
        thor.x -= 1
        thor.y -= 1
    else:
        thor.go_to = " "
        
# light_x: the X position of the light of power
# light_y: the Y position of the light of power
# initial_tx: Thor's starting X position
# initial_ty: Thor's starting Y position
light_x, light_y, initial_tx, initial_ty = [int(i) for i in input().split()]
thor = Thor(initial_tx, initial_ty)
# game loop
while True:
    remaining_turns = int(input())  # The remaining amount of turns Thor can move. Do not remove this line.

    walk_to_light(thor, light_x, light_y)
    print(thor.go_to)


