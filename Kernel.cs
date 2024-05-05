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
            Welcome.Clear(2);
            Welcome.Kwelcome();
        }

        protected override void Run()
        {
            try{
                Welcome.Konsole();
            }
            catch(Exception e){
                mDebugger.Send(e.Message);
                Console.WriteLine(e.Message);
            }
        }

        
    }
}
