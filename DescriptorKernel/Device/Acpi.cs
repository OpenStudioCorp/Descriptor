using Mosa;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;


namespace DescriptorKernel.Device.ACPI
{
    public class Acpi
    {
        public static void AcpiShutdown(){
            Mosa.DeviceDriver.ACPI.ACPIDriver aCPIDriver = new Mosa.DeviceDriver.ACPI.ACPIDriver();
            aCPIDriver.Stop();
       

        }
    }
}


