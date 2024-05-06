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
<<<<<<< HEAD
=======
using Cosmos.System.FileSystem.FAT;
using Cosmos.HAL.BlockDevice;
using Cosmos.System.FileSystem;
using System.IO;

>>>>>>> 5e4c2ddc586c0d1bf109bc3de4fa80aa2a6f9498
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
<<<<<<< HEAD
             
=======

>>>>>>> 5e4c2ddc586c0d1bf109bc3de4fa80aa2a6f9498
            switch (command)
            {
                case "help":
                    PrintS("help: print's the help text your reading");
                    PrintS("exit: exit the program");
                    PrintS("shutdown: shutdown the computer");
                    PrintS("restart: restart the computer");
                    PrintS("echo: prints out what you put in the args.");
<<<<<<< HEAD

                    break;
                case "echo":
                    Print(string.Join(" ", arguments) + "\n");

                    break;
                case "exit":
                    Print("Exting\n", ConsoleColor.Red);
                    Print("Thank you for using Descriptor\n");
                    Print("by: OpenStudio\n", ConsoleColor.Yellow);
=======

                    break;
                case "ls":
                    var files_list = Directory.GetFiles(@"0:\\");
                    var directory_list = Directory.GetDirectories(@"0:\\");

                    foreach (var file in files_list)
                    {
                        Print(file + "  ", ConsoleColor.Green);
                    }
                    foreach (var directory in directory_list)
                    {
                        Console.WriteLine(directory + "  ", ConsoleColor.DarkBlue);
                    }
                    Print("\n");
>>>>>>> 5e4c2ddc586c0d1bf109bc3de4fa80aa2a6f9498
                    
                    break;
                case "cat":
                    if (arguments.Length == 0) return;
                    string catFileName = "0:\\" + arguments[0];
                    try
                    {
                        using (FileStream fs = File.OpenRead(catFileName))
                        using (var sr = new StreamReader(fs))
                        {
                            string content = sr.ReadToEnd();
                            Console.WriteLine(content);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error reading file: " + e.Message);
                    }
                    break;
                case "echo":
                    string output = string.Join(" ", arguments);
                    if (output.Contains(">"))
                    {
                        string[] parts = output.Split(new[] { '>' }, 2, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length == 2)
                        {
                            string filename = "0:\\" + parts[1].Trim();
                            string textToAppend = parts[0].Trim();

                            if (!File.Exists(filename))
                                File.Create(filename);

                            try
                            {
                                using (StreamWriter sw = File.AppendText(filename))
                                {
                                    Print("Writing to file: " + filename + "\n");
                                    Print("Text to append: " + textToAppend + "\n");
                                    sw.Write(textToAppend);
                                }
                                Print("Text appended to " + filename + "\n");
                            }
                            catch (Exception e)
                            {
                                Print("Error appending text to file: " + e.Message + "\n", ConsoleColor.Red);
                            }
                        }
                        else
                        {
                            Print("Invalid syntax. Usage: echo [text] > [filename]\n", ConsoleColor.Red);
                        }
                    }
                    else
                    {
                        Print(string.Join(" ", arguments) + "\n");
                    }
                    break;
                case "exit":
                    Print("Exting\n", ConsoleColor.Red);
                    Print("Thank you for using Descriptor\n");
                    Print("by: OpenStudio\n", ConsoleColor.Yellow);

                    break;
                case "disk":
<<<<<<< HEAD
                    long free = Kernel.fs.GetAvailableFreeSpace(Kernel.Path);
                    Print("Free Space: " + free/1024 +"KB\n");
=======
                    long free = Kernel.fs.GetAvailableFreeSpace("0:\\");
                    if (((double)free / (1024 * 1024 * 1024)) > 0.9)
                        Print("Free Space: " + ((double)free / (1024 * 1024 * 1024)).ToString("0.##") + "GB\n");
                    else if (((double)free / (1024 * 1024)) > 1)
                        Print("Free Space: " + ((double)free / (1024 * 1024)).ToString("0.##") + "MB\n");
                    else
                        Print("Free Space: " + ((double)free / 1024).ToString("0") + "KB\n");
>>>>>>> 5e4c2ddc586c0d1bf109bc3de4fa80aa2a6f9498

                    break;
                case "shutdown":
                    Sys.Power.Shutdown(); // shutdown is supported

                    break;
                case "restart":
                    Sys.Power.Reboot(); // restart too

<<<<<<< HEAD
=======
                    break;

                case "format":
                    if (!arguments.Any()) {
                        Print("format [disk index] [format type]\n", ConsoleColor.Red);
                        return;
                    }
                    string diskindex = arguments[0];
                    if (arguments.Length < 2 || arguments[1] == null || string.IsNullOrWhiteSpace(arguments[1]))
                    {
                        Print($"format {diskindex} [format type]\n", ConsoleColor.Red);
                        return;
                    }
                    string format = arguments[1].ToUpper();
                    var index = int.Parse(diskindex);
                    try
                    {
                        Kernel.fs.Disks[index].FormatPartition(0, format);
                        Console.WriteLine("Disk formatted successfully.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error formatting disk: " + ex.Message);
                    }

>>>>>>> 5e4c2ddc586c0d1bf109bc3de4fa80aa2a6f9498
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
<<<<<<< HEAD
=======
        }
    }
    public class eidtor
    {
        public static void editor()
        {
           
>>>>>>> 5e4c2ddc586c0d1bf109bc3de4fa80aa2a6f9498
        }
    }
}
