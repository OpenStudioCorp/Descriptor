using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Mosa.DeviceSystem.HardwareAbstraction;
using Mosa.DeviceSystem.Services;
using Mosa.Kernel.BareMetal;

using Mosa.DeviceSystem.Disks;

using DescriptorKernel.Core;
using DescriptorKernel.Device;

namespace DescriptorKernel;
public static class Program {
	public static string Version = "0.1.0";
	public static DeviceService DeviceService { get; private set; }
	public static PCService PCService { get; private set; }
	public static Random Random { get; private set; }

	public static void EntryPoint() {
		Debug.WriteLine("Program::EntryPoint()");

		Console.ResetColor();
		Console.Clear();

		Logging.Info("Kernel", $"Initialising Descriptor Kernel (v{Version})");

		DeviceService = Kernel.ServiceManager.GetFirstService<DeviceService>();
		PCService = Kernel.ServiceManager.GetFirstService<PCService>();
		Random = new Random();

		Disks.ShowDisks();
		FileSystem.ShowPartitions();

		// Logging.Debug("Kernel", "This is a debug log.");
		// Logging.Warn("Kernel", "This is a warn log.");
		// Logging.Error("Kernel", "This is a error log.");		

		for (;;) {}
	}
}
