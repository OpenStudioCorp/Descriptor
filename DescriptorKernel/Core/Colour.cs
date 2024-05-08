
using System;
using Mosa.Kernel.BareMetal;
using Mosa.Runtime.Plug;

namespace DescriptorKernel.Core;

public static class Colour {
    public static class Foreground {
        public static string Black = "\x1b[30m";
        public static string DarkGrey = "\x1b[90m";
        public static string Grey = "\x1b[97m";
        public static string DarkRed = "\x1b[31m";
        public static string DarkGreen = "\x1b[32m";
        public static string DarkYellow = "\x1b[33m";
        public static string DarkBlue = "\x1b[34m";
        public static string DarkMagenta = "\x1b[35m";
        public static string DarkCyan = "\x1b[36m";
        public static string Red = "\x1b[91m";
        public static string Green = "\x1b[92m";
        public static string Yellow = "\x1b[93m";
        public static string Blue = "\x1b[94m";
        public static string Magenta = "\x1b[95m";
        public static string Cyan = "\x1b[96m";
        public static string White = "\x1b[37m";
        public static string Reset = "\x1b[37m";
    }

    public static class Background {
        public static string Black = "\x1b[40m";
        public static string DarkGrey = "\x1b[100m";
        public static string Grey = "\x1b[107m";
        public static string DarkRed = "\x1b[41m";
        public static string DarkGreen = "\x1b[42m";
        public static string DarkYellow = "\x1b[43m";
        public static string DarkBlue = "\x1b[44m";
        public static string DarkMagenta = "\x1b[45m";
        public static string DarkCyan = "\x1b[46m";
        public static string Red = "\x1b[101m";
        public static string Green = "\x1b[102m";
        public static string Yellow = "\x1b[103m";
        public static string Blue = "\x1b[104m";
        public static string Magenta = "\x1b[105m";
        public static string Cyan = "\x1b[106m";
        public static string White = "\x1b[47m";
        public static string Reset = "\x1b[47m";
    }
}
