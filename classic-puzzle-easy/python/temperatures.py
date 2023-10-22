import sys
import math


def closest(x, y):
    abs_x = abs(x)
    abs_y = abs(y)

    if abs_x == abs_y:
        return max(x, y)  # Return the positive value
    else:
        return x if abs_x < abs_y else y

temp_closest_zero = 10000 # In Python 3, the int type has no max limit. You can handle values as large as the available memory allows

n = int(input())  # the number of temperatures to analyse
for i in input().split():
    t = int(i)
    temp_closest_zero = closest(t, temp_closest_zero)

print(temp_closest_zero if temp_closest_zero != 10000 else 0)
