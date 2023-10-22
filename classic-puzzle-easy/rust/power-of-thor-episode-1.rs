use std::io;
use std::cmp::Ordering;

macro_rules! parse_input {
    ($x:expr, $t:ident) => ($x.trim().parse::<$t>().unwrap())
}
struct Thor {
    go_to: &'static str,
    x: i32,
    y: i32
}

fn main() {
    let mut input_line = String::new();
    io::stdin().read_line(&mut input_line).unwrap();
    let inputs = input_line.split(" ").collect::<Vec<_>>();
    let light_x = parse_input!(inputs[0], i32); // the X position of the light of power
    let light_y = parse_input!(inputs[1], i32); // the Y position of the light of power
    let initial_tx = parse_input!(inputs[2], i32); // Thor's starting X position
    let initial_ty = parse_input!(inputs[3], i32); // Thor's starting Y position

    let mut thor: Thor = Thor { go_to: "", x: initial_tx, y: initial_ty };

    // game loop
    loop {
        let mut input_line = String::new();
        io::stdin().read_line(&mut input_line).unwrap();
        let _remaining_turns = parse_input!(input_line, i32); // The remaining amount of turns Thor can move. Do not remove this line.

        walk_to_light(&mut thor, light_x, light_y);
        println!("{}", thor.go_to);
    }
}

fn walk_to_light(thor: &mut Thor, light_x: i32, light_y: i32) {
    thor.go_to = match (thor.x.cmp(&light_x), thor.y.cmp(&light_y)) {
        (Ordering::Less, Ordering::Equal) => {
            thor.x += 1;
            "E"
        },
        (Ordering::Greater, Ordering::Equal) => {
            thor.x -= 1;
            "W"
        },
        (Ordering::Equal, Ordering::Less) => {
            thor.y += 1;
            "S"
        },
        (Ordering::Greater, Ordering::Less) => {
            thor.x -= 1;
            thor.y += 1;
            "SW"
        },
        (Ordering::Less, Ordering::Less) => {
            thor.x += 1;
            thor.y += 1;
            "SE"
        },
        (Ordering::Equal, Ordering::Greater) => {
            thor.y -= 1;
            "N"
        },
        (Ordering::Less, Ordering::Greater) => {
            thor.x += 1;
            thor.y -= 1;
            "NE"
        },
        (Ordering::Greater, Ordering::Greater) => {
            thor.x -= 1;
            thor.y -= 1;
            "NW"
        },
        _ => " ",
    };
}