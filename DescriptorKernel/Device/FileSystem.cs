using System;
using Mosa.DeviceSystem.Disks;
using Mosa.FileSystem.FAT;

using DescriptorKernel.Core;

namespace DescriptorKernel.Device;

public static class FileSystem {
	public static void ShowPartitions() {
		Logging.Info("Device.FileSystem", "Looking for partitions.");
		var partitions = Program.DeviceService.GetDevices<IPartitionDevice>();

		if (partitions.Count <= 0) {
			Logging.Warn("Device.FileSystem", "No partitions were found.");
			return;
		}

		Logging.Info("Device.FileSystem", $"{partitions.Count} partition(s) found.");
		foreach (var partition in partitions) {
			Logging.Info("Device.FileSystem", $"Found partition {partition.Name} with {(partition.DeviceDriver as IPartitionDevice).BlockCount} blocks.");
		}

		Logging.Info("Device.FileSystem", "Looking for file systems.");

		bool foundFileSystem = false;
		foreach (var partition in partitions) {
			var fat = new FatFileSystem(partition.DeviceDriver as IPartitionDevice);
			if (!fat.IsValid) continue;

			foundFileSystem = true;
			Logging.Info("Device.FileSystem", $"Found FAT{(int)fat.FATType} file system with name \"{fat.VolumeLabel}\" on {partition.Name}.");
		}

		if (!foundFileSystem) {
			Logging.Warn("Device.FileSystem", "No valid file systems were found.");
			return;
		}

	}
}