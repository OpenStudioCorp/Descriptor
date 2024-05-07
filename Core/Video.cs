using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.Core;

//using CSystem.Text.RegularExpressions; // using System.Text.RegularExpressions; Fixed in .net 8

namespace Descriptor.Core
{
    internal class Video
    {
        public static void Printf(string text)
        {
            
            int index = 0;
            while (index < text.Length)
            {
                if (text[index] == '\u001b' && text[index + 1] == '[')
                {
                    int endIndex = text.IndexOf('m', index);
                    if (endIndex != -1)
                    {
                        string code = text.Substring(index + 2, endIndex - index - 2);
                        
                        string colourCode = "0";
                        if (code.Contains(';'))
                            colourCode = code.Split(';')[1];

                        if (int.TryParse(colourCode, out int colorNum))
                        {
                            Console.ForegroundColor = GetConsoleColor(colorNum);
                        }
                        index = endIndex + 1;
                        continue;
                    }
                }

                Console.Write(text[index]);
                index++;
            }
        }

        static ConsoleColor GetConsoleColor(int colorCode)
        {
            switch (colorCode)
            {
                case 30: return ConsoleColor.Black;
                case 31: return ConsoleColor.Red;
                case 32: return ConsoleColor.Green;
                case 33: return ConsoleColor.Yellow;
                case 34: return ConsoleColor.Blue;
                case 35: return ConsoleColor.Magenta;
                case 36: return ConsoleColor.Cyan;
                case 37: return ConsoleColor.White;
                default: return ConsoleColor.White;
            }
        }
    }

    internal class Colours8
    {
        public static string Black { get; } = "\u001b[0;30m";
        public static string Red { get; } = "\u001b[0;31m";
        public static string Green { get; } = "\u001b[0;32m";
        public static string Yellow { get; } = "\u001b[0;33m";
        public static string Blue { get; } = "\u001b[0;34m";
        public static string Purple { get; } = "\u001b[0;35m";
        public static string Cyan { get; } = "\u001b[0;36m";
        public static string White { get; } = "\u001b[0;37m";
    }
}
