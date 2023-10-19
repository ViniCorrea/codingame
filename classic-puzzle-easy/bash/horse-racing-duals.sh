#!/bin/bash

declare -a strengths

read -r N
for (( i=0; i<$N; i++ )); do
    read -r Pi
    strengths[$i]=$Pi
done

IFS=$'\n' sorted=($(sort -n <<<"${strengths[*]}")) # -n, --numeric-sort     compare according to string numerical value
unset IFS

minDiff=10000001  # A value greater than the maximum allowed strength

for ((i=1; i<N; i++)); do
    diff=$((sorted[i] - sorted[i-1]))
    if [ $diff -lt $minDiff ]; then
        minDiff=$diff
    fi
done

echo "$minDiff"