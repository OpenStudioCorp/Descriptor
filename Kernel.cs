using Cosmos.System.FileSystem;
using System;
using Sys = Cosmos.System;
using System.Threading;
using System.Reflection.Metadata;
namespace Descriptor
{
    public class Kernel : Sys.Kernel
    {
        public string Version = "1.0.0";
        public static string Path = @"0:\\";
        public static CosmosVFS fs;
        protected override void BeforeRun()
        {
#pragma warning disable CA1416 // Validate platform compatibility
            Console.SetWindowSize(90, 30);
#pragma warning restore CA1416 // Validate platform compatibility
            Console.OutputEncoding = Cosmos.System.ExtendedASCII.CosmosEncodingProvider.Instance.GetEncoding(437);
            CosmosVFS fs = new Cosmos.System.FileSystem.CosmosVFS();
            Cosmos.System.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            Konsol.Kwelcome();
        }
    
        protected override void Run()
        {
            
            try
            {
                Konsol.Konsole("$: ", Path);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Konsol.HandleKernelPanic(e);
            }


        }
    }
}
