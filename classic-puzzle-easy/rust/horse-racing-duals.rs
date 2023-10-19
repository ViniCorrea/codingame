use std::io;

macro_rules! parse_input {
    ($x:expr, $t:ident) => ($x.trim().parse::<$t>().unwrap())
}

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
fn main() {
    let mut input_line = String::new();
    io::stdin().read_line(&mut input_line).unwrap();
    let n = parse_input!(input_line, i32);
    
    let mut strengths: Vec<i32> = Vec::new();

    for _ in 0..n as usize {
        let mut input_line = String::new();
        io::stdin().read_line(&mut input_line).unwrap();
        let pi = parse_input!(input_line, i32);
        
        strengths.push(pi);
    }
    strengths.sort();

    let mut min_diff = std::i32::MAX;

    for i in 0..(n-1) as usize {
        let diff = strengths[i + 1] - strengths[i];
        if diff < min_diff {
            min_diff = diff;
        }
    }

    println!("{}", min_diff);
}


