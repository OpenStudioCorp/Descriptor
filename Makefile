

dev:


setup:
	rustup target add x86_64-unknown-none
	rustup component add rust-src
	rustup component add llvm-tools-preview
clean:
	rm -r target/

push:
  git add *
  git commit -m "$(msg)" # make push msg="i fixed the issue"
  git push


cargo clean
cargo build
cargo run