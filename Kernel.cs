using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace Descriptor
{
    public class Kernel : Sys.Kernel
    {

        protected override void BeforeRun()
        {
            Welcome();
        }

        protected override void Run()
        {
         
        }
    }
}
