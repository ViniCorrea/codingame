#!/bin/bash

line1=" _     _  _     _  _  _  _  _ "
line2="| |  | _| _||_||_ |_   ||_||_|"
line3="|_|  ||_  _|  | _||_|  ||_| _|"

segments=(" _ | ||_|" "     |  |" " _  _||_ " " _  _| _|" "   |_|  |" " _ |_  _|" " _ |_ |_|" " _   |  |" " _ |_||_|" " _ |_| _|")

result=""

for ((i = 0; i < ${#line1}; i += 3)); do
    currentSegment="${line1:$i:3}${line2:$i:3}${line3:$i:3}"
    number=""
    for ((j = 0; j < ${#segments[@]}; j++)); do
        if [ "${segments[j]}" = "$currentSegment" ]; then
            number=$j
            break
        fi
    done

    if [ -n "$number" ]; then
        result="${result}${number}"
    else
        result="${result}X"
    fi
done

echo "$result"
