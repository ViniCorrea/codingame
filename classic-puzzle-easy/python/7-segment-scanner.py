import sys
import math

segment_dict = {
    " _ | ||_|": '0',
    "     |  |": '1',
    " _  _||_ ": '2',
    " _  _| _|": '3',
    "   |_|  |": '4',
    " _ |_  _|": '5',
    " _ |_ |_|": '6',
    " _   |  |": '7',
    " _ |_||_|": '8',
    " _ |_| _|": '9'
}

line_1 = " _     _  _     _  _  _  _  _ " # input()
line_2 = "| |  | _| _||_||_ |_   ||_||_|" # input()
line_3 = "|_|  ||_  _|  | _||_|  ||_| _|" # input()

# Initialize an empty string to store the result
result = ""

# Loop through display
for i in range(0, len(line_1), 3):
    # taking 3 characters from each lin
    current_segment = line_1[i:i+3] + line_2[i:i+3] + line_3[i:i+3]

    # Look up the current_segment in segment_dict and append the corresponding digit to the result
    result += segment_dict[current_segment]

print(result)




