using System;
using Sys = Cosmos.System;
using System.Threading;
using System.Reflection.Metadata;

using Descriptor.Core;
using static Descriptor.Core.Video;
using System.Runtime.InteropServices;

namespace Descriptor
{
    public class Kernel : Sys.Kernel
    {
        public string Version = "0.1.0";
        public static string Path = @"0:\\";
        //public static CosmosVFS fs;
        protected override void BeforeRun()
        {
            Logging.Clear();
            Logging.Info("Kernel", string.Format("Starting Descriptor kernel (v{0}).", Version));

            Logging.Info("Kernel", "Info log test.");
            Logging.Warn("Kernel", "Warn log test.");
            Logging.Error("Kernel", "Error log test.");

            FileSystem.StartFileSystem();


            //#pragma warning disable CA1416 // Validate platform compatibility
            //            Console.SetWindowSize(90, 30);
            //#pragma warning restore CA1416 // Validate platform compatibility
            //            Console.OutputEncoding = Sys.ExtendedASCII.CosmosEncodingProvider.Instance.GetEncoding(437);
            //            CosmosVFS fs = new CosmosVFS();
            //            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
        }

        protected override void Run()
        {

            try
            {
                //Konsol.Konsole("$: ", Path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                //Konsol.HandleKernelPanic(e);
            }
        }
    }
}
