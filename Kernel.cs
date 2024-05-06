using Cosmos.System.FileSystem;
using System;
using Sys = Cosmos.System;

namespace Descriptor
{
    public class Kernel : Sys.Kernel
    {
        public string Version = "1.0.0";
        public static string Path = @"0\";
        public static CosmosVFS fs;
        protected override void BeforeRun()
        {
            Console.SetWindowSize(90, 30);
            Console.OutputEncoding = Cosmos.System.ExtendedASCII.CosmosEncodingProvider.Instance.GetEncoding(437);
            CosmosVFS fs = new Cosmos.System.FileSystem.CosmosVFS();
            Cosmos.System.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            Konsol.Kwelcome();
        }

        protected override void Run()
        {
            Konsol.Konsole("$: ", Path);

        }
    }
}
