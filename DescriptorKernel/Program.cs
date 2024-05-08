using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Mosa.DeviceSystem.HardwareAbstraction;
using Mosa.DeviceSystem.Services;
using Mosa.Kernel.BareMetal;

using Mosa.DeviceSystem.Disks;
using Mosa.FileSystem.FAT;

using DescriptorKernel.Core;
using DescriptorKernel.Device;
using Mosa.DeviceSystem.Framework;

namespace DescriptorKernel;
public static class Program {
	public static string Version = "0.1.0";
	public static DeviceService DeviceService { get; private set; }
	public static PCService PCService { get; private set; }
	public static Random Random { get; private set; }
	
	public static FatFileSystem RootFileSystem { get; private set; }

	public static void EntryPoint() {
		Debug.WriteLine("Program::EntryPoint()");

		Console.ResetColor();
		Console.Clear();

		Logging.Info("Kernel", $"Initialising Descriptor Kernel (v{Version}).");

		DeviceService = Kernel.ServiceManager.GetFirstService<DeviceService>();
		PCService = Kernel.ServiceManager.GetFirstService<PCService>();
		

		Disks.ShowDisks();
		FileSystem.ShowPartitions();
		
       

		Logging.Info("Kernel", "Loading root file system.");
		var partitions = DeviceService.GetDevices<IPartitionDevice>();

		if (partitions.Count <= 0) {
			Logging.Error("Kernel", "No partitions were found, halting.");
			while (true);
		}

		RootFileSystem = new FatFileSystem(partitions[0].DeviceDriver as IPartitionDevice);

		if (!RootFileSystem.IsValid) {
			Logging.Error("Kernel", "The root file sytem is missing or corrupted, halting.");
			while (true);
		}

		Logging.Info("Kernel", $"Loaded the root filesytem with name \"{RootFileSystem.VolumeLabel}\".");

		Logging.Warn("Kernel", "Formatting root file system.");
		FatSettings fatSettings = new FatSettings();
		fatSettings.FATType = FatType.FAT32;
		fatSettings.FloppyMedia = false;
		RootFileSystem.Format(fatSettings);
		RootFileSystem.SetVolumeName("DSOSROOT");

		Logging.Info("Kernel", "Finished!");
		Logging.Info("Kernel", $"New filesystem name: \"{RootFileSystem.VolumeLabel}\".");
		Logging.Info("Kernel", $"New filesystem type: FAT{(int)RootFileSystem.FATType}.");
		Konsole.Konsole.run();
		// Mosa.Kernel.BareMetal.elf

		// Logging.Debug("Kernel", "This is a debug log.");
		// Logging.Warn("Kernel", "This is a warn log.");
		// Logging.Error("Kernel", "This is a error log.");		

        for (;;) {}
	}
}
