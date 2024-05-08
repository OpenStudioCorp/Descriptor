using Mosa.Kernel.BareMetal;
using Mosa.Runtime.Plug;

namespace DescriptorKernel;

internal class Boot {
    [Plug("Mosa.Runtime.StartUp::BootOptions")]
	public static void SetBootOptions() {
		BootSettings.EnableDebugOutput = true;
		// BootSettings.EnableVirtualMemory = true;
		// BootSettings.EnableMinimalBoot = true;
	}
}