using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using DescriptorKernel.Core;
using DescriptorKernel.Device.ACPI;
using Mosa.DeviceDriver.ACPI;
using Mosa.Kernel.BareMetal.IPC;


namespace Konsole
{
    public class Konsole
    {   
        public static void help()
        {
            PrintN("Welcome to Konsole!", ConsoleColor.Green);
            PrintN("Color codes are:", ConsoleColor.Green);
            PrintN("Green: good", ConsoleColor.Green);
            PrintN("Red: bad", ConsoleColor.Red);
            PrintN("Yellow: warning", ConsoleColor.Yellow);
            PrintN("Blue: info", ConsoleColor.Blue);
            PrintN("gray: debug", ConsoleColor.Gray);
            PrintN("Cyan: trace\n", ConsoleColor.Cyan);
            PrintN("Here are some commands:", ConsoleColor.Green);
          
            PrintN("exit", ConsoleColor.Green);
            PrintN("clear", ConsoleColor.Green);
            PrintN("help", ConsoleColor.Green);
            PrintN("wasm <filename>", ConsoleColor.Green);
        }
        public static void PrintF(string Text,ConsoleColor color) // doesnt print new line
        {
            Console.ForegroundColor = color;
            Console.Write(Text);
            Console.ResetColor();
        }
        public static void PrintN(string Text, ConsoleColor color) // prints new line
        {
            Console.ForegroundColor = color;
            Console.WriteLine(Text);
            Console.ResetColor();
        }
        public static void run()
        {   
            while (true)
            {
                PrintF(">", ConsoleColor.Green);
            string input = Console.ReadLine();
            string[] args = input.Split(" ");
            string command = args[0];
            switch (command)
            {
                case "exit":
                    PrintN("Bye!", ConsoleColor.Red);
                    //Acpi.AcpiShutdown();
                    Environment.Exit(0);
                    break;
                case "clear":
                    Console.Clear();
                    break;
                case "help":
                    help(); // help command
                    break;
                    
                case "wasm":
                    if (args.Length < 2)
                    {
                        PrintN("Usage: wasm <filename>", ConsoleColor.Red);
                        break;
                    }
                    else{
                    //string filename = args[1];

                    //Wasm.run(filename);
                    
                    PrintN("Wasm not implemented yet!", ConsoleColor.Red);
                    // PrintN(filename, ConsoleColor.Green);
                    }
                    break;

                default:
                    PrintN("Command not found!", ConsoleColor.Red);
                    break;
            }
            }


        }
    }
}
