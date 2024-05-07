using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Descriptor.Core.Video;

namespace Descriptor.Core
{
    internal class Logging
    {
        internal static void Info(string location, string message) {
            Printf(String.Format("[\u001b[0;32mInfo\u001b[0m] [\u001b[0;34m{0}\u001b[0m] {1}\n", location, message));
        }

        internal static void Warn(string location, string message)
        {
            Printf(String.Format("[\u001b[0;33mWarn\u001b[0m] [\u001b[0;34m{0}\u001b[0m] {1}\n", location, message));
        }

        internal static void Error(string location, string message) {
            Printf(String.Format("[\u001b[0;31mError\u001b[0m] [\u001b[0;34m{0}\u001b[0m] {1}\n", location, message));
        }


        internal static void Fatal(string location, string message) {
            Printf(String.Format("[Fatal] [{0}] {1}\n", location, message));
        }

        internal static void Clear() { Console.Clear(); }
    }
}
