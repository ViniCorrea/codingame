#![allow(unused_variables)]
#![allow(unused_mut)]


//use std::io;

// macro_rules! parse_input {
//     ($x:expr, $t:ident) => ($x.trim().parse::<$t>().unwrap())
// }

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
fn main() {

    // let mut input_line = String::new();
    // io::stdin().read_line(&mut input_line).unwrap();
    // let line_1 = input_line.trim_matches('\n').to_string();
    // let mut input_line = String::new();
    // io::stdin().read_line(&mut input_line).unwrap();
    // let line_2 = input_line.trim_matches('\n').to_string();
    // let mut input_line = String::new();
    // io::stdin().read_line(&mut input_line).unwrap();
    // let line_3 = input_line.trim_matches('\n').to_string();
    let line_1 = " _     _  _     _  _  _  _  _ ";
    let line_2 = "| |  | _| _||_||_ |_   ||_||_|";
    let line_3 = "|_|  ||_  _|  | _||_|  ||_| _|";
 
    let mut result = String::new();
    
    // Loop through the display
    for i in (0..line_1.len()).step_by(3) {
        let current_segment = [&line_1[i..i + 3], &line_2[i..i + 3].to_string(), &line_3[i..i + 3]].join("");
        let current_segment_str = current_segment.as_str();
        let number = match current_segment_str {
            " _ | ||_|" => '0',
            "     |  |" => '1',
            " _  _||_ " => '2',
            " _  _| _|" => '3',
            "   |_|  |" => '4',
            " _ |_  _|" => '5',
            " _ |_ |_|" => '6',
            " _   |  |" => '7',
            " _ |_||_|" => '8',
            " _ |_| _|" => '9',
            _ => 'X'
        };

        result.push(number);
    }
    
    println!("{}", result);
}
