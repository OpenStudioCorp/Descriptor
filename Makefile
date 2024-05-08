PLATFORM=DescriptorKernel.x86


all: build run

build:
	dotnet build

push:
	git add *
	git commit -m "$(msg)"
	git push


run:
	$(PLATFORM)/bin/Tools/Mosa.Tool.Launcher.console $(PLATFORM)/bin/$(PLATFORM).dll
