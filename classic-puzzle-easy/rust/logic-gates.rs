use std::collections::HashMap;
use std::io;

fn main() {
    let mut input = String::new();

    // Read the number of input signals
    io::stdin().read_line(&mut input).unwrap();
    let n: usize = input.trim().parse().unwrap();
    input.clear();

    // Read the number of output signals
    io::stdin().read_line(&mut input).unwrap();
    let m: usize = input.trim().parse().unwrap();
    input.clear();

    let mut input_signals = HashMap::new();

    // Read the input signals
    for _ in 0..n {
        io::stdin().read_line(&mut input).unwrap();
        let parts: Vec<&str> = {
            input.trim().split_whitespace().collect()
        };
        let signal_vec = parts[1].chars().map(|c| c == '-').collect::<Vec<bool>>();
        input_signals.insert(parts[0].to_string(), signal_vec);
        input.clear();
    }

    // Read the output specifications and compute results
    for _ in 0..m {
        io::stdin().read_line(&mut input).unwrap();
        let parts: Vec<&str> = {
            input.trim().split_whitespace().collect()
        };

        let output_name = parts[0].to_string();
        let gate_type = parts[1];
        let input_signal1 = input_signals.get(parts[2]).unwrap();
        let input_signal2 = input_signals.get(parts[3]).unwrap();

        // Perform gate operation and create the output signal
        let output_signal: String = input_signal1
            .iter()
            .zip(input_signal2.iter())
            .map(|(&b1, &b2)| match gate_type { //closure ( | ) is an anonymous function that can capture variables from its surrounding scope
                "AND" => if b1 && b2 { '-' } else { '_' },
                "OR" => if b1 || b2 { '-' } else { '_' },
                "XOR" => if b1 ^ b2 { '-' } else { '_' },
                "NAND" => if !(b1 && b2) { '-' } else { '_' },
                "NOR" => if !(b1 || b2) { '-' } else { '_' },
                "NXOR" => if !(b1 ^ b2) { '-' } else { '_' },
                _ => unreachable!(),
            })
            .collect();

        println!("{} {}", output_name, output_signal);
        input.clear();
    }
}
