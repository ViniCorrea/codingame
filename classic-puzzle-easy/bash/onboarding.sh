# CodinGame planet is being attacked by slimy insectoid aliens.
# <---
# Hint:To protect the planet, you can implement the pseudo-code provided in the statement, below the player.


# game loop
while true; do
    # enemy1: name of enemy 1
    read -r enemy1
    # dist1: distance to enemy 1
    read -r dist1
    # enemy2: name of enemy 2
    read -r enemy2
    # dist2: distance to enemy 2
    read -r dist2

    # Write an action using echo
    # To debug: echo "Debug messages..." >&2


    if ((dist1 < dist2)); then
        echo "$enemy1"
    else
        echo "$enemy2"
    fi
done