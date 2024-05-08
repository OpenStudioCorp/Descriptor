
using System;
using Mosa.Kernel.BareMetal;
using Mosa.Runtime.Plug;

using DescriptorKernel.Core;
using Mosa.DeviceSystem.TextDevice;

namespace DescriptorKernel;
public static class Program
{
	public static string Version = "0.1.0";

	[Plug("Mosa.Runtime.StartUp::BootOptions")]
	public static void SetBootOptions()
	{
		BootSettings.EnableDebugOutput = true;
		BootSettings.EnableVirtualMemory = true;
		BootSettings.EnableMinimalBoot = true;
	}

	public static void EntryPoint()
	{
		Debug.WriteLine("Program::EntryPoint()");

		Console.ResetColor();
		Console.Clear();

		Logging.Info("Kernel", $"Initialising Descriptor Kernel (v{Version})");

		// Logging.Debug("Kernel", "This is a debug log.");
		// Logging.Warn("Kernel", "This is a warn log.");
		// Logging.Error("Kernel", "This is a error log.");		

		for (; ; )
		{ }
	}
}
