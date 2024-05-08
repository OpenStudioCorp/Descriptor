# Descriptor

---
# Welcome to Descriptor!

This is the home for descriptor. a operating system developed in Rust with support for loading WASM compiled software

Descriptor is the successor to the discontinued project, "PythonicOS". Descriptor will be a 32-bit operating system with a focus on security, stability, and performance. It will be designed to be modular and extensible, allowing users to easily add new features and functionality.

## Features

Descriptor will include a number of features, including:

* A preemptive multitasking kernel * 
* A virtual memory system 
* A file system 
* A networking stack *
* A command-line interface
* A package manager * 
* A build system  
* A debugger 
* A profiler * 
* A test suite * 

anything marked with * at the end is in development at the moment and does not reflect the current implementation of the Shell

## Development

Descriptor is currently in the early stages of development. The project is open source and contributions are welcome.

## Getting Started

To get started with Descriptor, you can clone the repository from GitHub:

```
git clone https://github.com/OpenStudioCorp/Descriptor.git
```

Once you have cloned the repository, you can build Descriptor by running the following command:

```
make
```

This will build the Descriptor kernel and all of the userland applications.

## Documentation

The Descriptor documentation is available online at:

https://descriptoros.vercel.app


## Contributing

Contributions to Descriptor are welcome. Please see the CONTRIBUTING.md file for more information.

## License

Descriptor is licensed under the MIT License.

## Disclaimer

Descriptor is currently in development and is nowhere near finished to call stable. 

you can use it but right now, since it's in very early stages. it's best to wait till a stable release is made.

## Setup
rustup target add x86_64-unknown-none
rustup component add rust-src
rustup component add llvm-tools-preview