using Mosa;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using Mosa.DeviceSystem.HardwareAbstraction;


namespace DescriptorKernel.Device.ACPI
{
    public class Acpi
    {
        public static void AcpiShutdown(){
            HAL.Yield();
        }
    }
}