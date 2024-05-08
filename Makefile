PLATFORM=DescriptorKernel.x86

all: build run

build:
	dotnet build

run:
	$(PLATFORM)/bin/Tools/Mosa.Tool.Launcher.console $(PLATFORM)/bin/$(PLATFORM).dll