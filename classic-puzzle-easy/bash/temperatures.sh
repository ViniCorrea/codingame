#!/bin/bash

closest()
 {
    local x="$1"
    local y="$2"
    
    local absX="${x#-}"  # ${var#Pattern} Remove from $var the shortest part of $Pattern that matches the front end of $var
    local absY="${y#-}"  # ${var#Pattern} Remove from $var the shortest part of $Pattern that matches the front end of $var
 
    if (( absX < absY )); then
        echo "$x"
    elif (( absX > absY )); then
        echo "$y"
    else  # When absX == absY
        (( x > y )) && echo "$x" || echo "$y"
    fi
 }


# n: the number of temperatures to analyse
read -r n

# Check if n is zero and handle that case
if (( n == 0 )); then
    echo 0
    exit 0
fi

read -r -a myArray
tempClosestZero=10000
for (( i=0; i<$n; i++ )); do
    # t: a temperature expressed as an integer ranging from -273 to 5526
    t=${myArray[$((i))]}
    tempClosestZero=$(closest "$t" "$tempClosestZero")
done

# If tempClosestZero remains the large positive value, reset to 0
(( tempClosestZero == 10000)) && tempClosestZero=0

echo "$tempClosestZero"