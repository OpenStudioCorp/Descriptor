#![no_std]
#![feature(abi_x86_interrupt)]

use core::panic::PanicInfo;

pub mod interrupts;
pub mod serial;
pub mod vga;

pub fn init() {
    interrupts::init_idt();
}
