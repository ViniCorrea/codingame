use std::io;

macro_rules! parse_input {
    ($x:expr, $t:ident) => ($x.trim().parse::<$t>().unwrap())
}

fn main() {
    let mut input_line = String::new();
    io::stdin().read_line(&mut input_line).unwrap();
    let n = parse_input!(input_line, i32); // the number of temperatures to analyse
    let mut inputs = String::new();
    io::stdin().read_line(&mut inputs).unwrap();
    
    let mut temp_closest_zero = std::i32::MAX;
    
    for i in inputs.split_whitespace() {
        let t = parse_input!(i, i32);
        temp_closest_zero = closest(t, temp_closest_zero)
    }

    println!("{}", if temp_closest_zero == std::i32::MAX { 0 } else { temp_closest_zero })
}

fn closest(x: i32, y: i32) -> i32 {
    let abs_x = x.abs();
    let abs_y = y.abs();

    if abs_x < abs_y {
        x
    } else if abs_x > abs_y {
        y
    } else if abs_x == abs_y {
        x.max(y)
    } else {
        x
    }
}