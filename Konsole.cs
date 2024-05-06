using Cosmos.Debug.Kernel;
using Cosmos.Debug;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;
using System.Drawing;
using System.Collections;
namespace Descriptor
{
    public class Konsol
    {

        public static void Clear(int times)
        {
            for (int i = 0; i < times; i++)
            {
                Console.WriteLine();
            }
        }
        public static void PrintS(string text)
        {
            Console.Write(CenterText(text));
        }

        public static void Print(string text)
        {
            Console.Write(text);
        }

        public static void Print(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }

        public static void PrintS(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(CenterText(text));
            Console.ResetColor();
        }

        public static string CenterText(string text)
        {
            int consolewidth = 90;
            int padding = (consolewidth - text.Length) / 2;
            string centeredText = text.PadLeft(padding + text.Length).PadRight(consolewidth);
            return centeredText;
        }

        public static void Konsole(string caret, string path)
        {
            Console.Write(path + caret);

            string input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                // this stops the crash whenever you put nothing in the command line
                return;
            }

            string[] inputParts = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string command = inputParts[0];

            string[] arguments = new string[inputParts.Length - 1];
            Array.Copy(inputParts, 1, arguments, 0, inputParts.Length - 1);

            switch (command)
            {
                case "help":
                    PrintS("help: print's the help text your reading");
                    PrintS("exit: exit the program");
                    PrintS("shutdown: shutdown the computer");
                    PrintS("restart: restart the computer");
                    PrintS("echo: prints out what you put in the args.");

                    break;
                case "echo":
                    Print(string.Join(" ", arguments) + "\n");

                    break;
                case "exit":
                    Print("Exting\n", ConsoleColor.Red);
                    Print("Thank you for using Descriptor\n");
                    Print("by: OpenStudio\n", ConsoleColor.Yellow);

                    break;
                case "disk":
                    long free = Kernel.fs.GetAvailableFreeSpace(Kernel.Path);
                    Print("Free Space: " + free / 1024 + "KB\n");

                    break;
                case "shutdown":
                    Sys.Power.Shutdown(); // shutdown is supported

                    break;
                case "restart":
                    Sys.Power.Reboot(); // restart too

                    break;
                default:
                    Print("invalid input: " + input + "\n", ConsoleColor.Red);

                    break;
            }

        }
        public static void Kwelcome()
        {
            PrintS("########################", ConsoleColor.Green);
            PrintS("####---Descriptor---####", ConsoleColor.Green);
            PrintS("########################", ConsoleColor.Green);
            PrintS("########--V1.0--########", ConsoleColor.Green);
            PrintS("########################", ConsoleColor.Green);
            PrintS("########################", ConsoleColor.Green);
            PrintS("#####--Created by--#####", ConsoleColor.Green);
            PrintS("#####--OpenStudio--#####", ConsoleColor.Green);
            PrintS("########################", ConsoleColor.Green);
        }
    }
}
