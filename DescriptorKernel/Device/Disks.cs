using System;
using Mosa.DeviceSystem.Disks;

using DescriptorKernel.Core;

namespace DescriptorKernel.Device;

public static class Disks {
	public static void ShowDisks() {
		Logging.Info("Device.Disks", "Looking for disk controllers.");
		var diskControllers = Program.DeviceService.GetDevices<IDiskControllerDevice>();

		if (diskControllers.Count <= 0) {
			Logging.Warn("Device.Disks", "No disk controllers were found.");
			return;
		}

		Logging.Info("Device.Disks", $"{diskControllers.Count} disk controllers(s) found.");
		foreach (var device in diskControllers) {
			Logging.Info("Device.Disks", $"Found disk controller {device.Name} with id {device.ComponentID}.");
		}
	
		Logging.Info("Device.Disks", "Looking for disks.");
		var disks = Program.DeviceService.GetDevices<IDiskDevice>();

		if (disks.Count <= 0) {
			Logging.Warn("Device.Disks", "No disks were found.");
			return;
		}

		Logging.Info("Device.Disks", $"{disks.Count} disk(s) found.");
		foreach (var disk in disks) {
			Logging.Info("Device.Disks", $"Found disk {disk.Name} with id ({disk.ComponentID}) and {(disk.DeviceDriver as IDiskDevice).TotalBlocks} blocks.");
		}
	}
}