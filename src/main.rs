#![no_std]
#![no_main]

use descriptor::println;
use core::panic::PanicInfo;

#[no_mangle]
pub extern "C" fn _start() -> ! {
    println!("Hello, World{}", "!");
    
    descriptor::init();

    x86_64::instructions::interrupts::int3();

    println!("Hello, World! Pt 2");
    loop {}
}

#[panic_handler]
fn panic(_info: &PanicInfo) -> ! {
    println!("{}", _info);
    loop {}
}

