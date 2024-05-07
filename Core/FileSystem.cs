using Cosmos.System.FileSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;

namespace Descriptor.Core
{
    internal class FileSystem
    {
        public static Sys.FileSystem.CosmosVFS FatVirtualFileSystem = new Sys.FileSystem.CosmosVFS();

        public static void StartFileSystem()
        {
            Logging.Info("FileSystem", "Initialising filesystem.");
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(FatVirtualFileSystem);

            if (FatVirtualFileSystem.GetVolumes().Count > 0) {
                Logging.Info("FileSystem", String.Format("Initialised filesystem with {0} volumes.", FatVirtualFileSystem.GetVolumes().Count));
            } else
            {
                Logging.Error("FileSystem", "Faild to initialise filesystem.");
            }
        }
    }
}
