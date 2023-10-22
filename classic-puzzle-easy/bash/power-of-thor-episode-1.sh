#!/bin/bash

# Define Thor as an associative array
declare -A thor

walkToLight() {
    local lightX=$1
    local lightY=$2

    if (( ${thor[X]} < lightX )) && (( ${thor[Y]} == lightY )); then
        thor[GoTo]="E"
        ((thor[X]++))
    elif (( ${thor[X]} > lightX )) && (( ${thor[Y]} == lightY )); then
        thor[GoTo]="W"
        ((thor[X]--))
    elif (( ${thor[X]} == lightX )) && (( ${thor[Y]} < lightY )); then
        thor[GoTo]="S"
        ((thor[Y]++))
    elif (( ${thor[X]} > lightX )) && (( ${thor[Y]} < lightY )); then
        thor[GoTo]="SW"
        ((thor[X]--))
        ((thor[Y]++))
    elif (( ${thor[X]} < lightX )) && (( ${thor[Y]} < lightY )); then
        thor[GoTo]="SE"
        ((thor[X]++))
        ((thor[Y]++))
    elif (( ${thor[X]} == lightX )) && (( ${thor[Y]} > lightY )); then
        thor[GoTo]="N"
        ((thor[Y]--))
    elif (( ${thor[X]} < lightX )) && (( ${thor[Y]} > lightY )); then
        thor[GoTo]="NE"
        ((thor[X]++))
        ((thor[Y]--))
    elif (( ${thor[X]} > lightX )) && (( ${thor[Y]} > lightY )); then
        thor[GoTo]="NW"
        ((thor[X]--))
        ((thor[Y]--))
    else
        thor[GoTo]="ERROUUUUU"
    fi
}

# lightX: the X position of the light of power
# lightY: the Y position of the light of power
# initialTX: Thor's starting X position
# initialTY: Thor's starting Y position
read -r lightX lightY initialTX initialTY

# Ensure the variables are treated as integers
lightX=$((lightX))
lightY=$((lightY))
initialTX=$((initialTX))
initialTY=$((initialTY))

# Initialize Thor's starting position
thor[X]=$initialTX
thor[Y]=$initialTY
thor[GoTo]=""

# game loop
while true; do
    # remainingTurns: The remaining amount of turns Thor can move. Do not remove this line.
    read -r remainingTurns

    walkToLight "$lightX" "$lightY"
    echo "${thor[GoTo]}"
done
