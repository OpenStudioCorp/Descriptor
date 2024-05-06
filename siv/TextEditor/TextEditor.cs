using InteractiveReadLine;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace siv.TextEditor
{
    public static class TextEditor
    {
        public static int yTextLines = 0;

        public static string fileName = "NewTextFile.txt";
        public static string filePath = $"/home/{Environment.UserName}/{fileName}";

        public static Canvas textCanvas = new Canvas();

        public static void StartTextEditor()
        {
            Console.Clear();
            Other.ConsoleFunction.PrintTopBar("Siv Text editor | Created by Nevixity | Press Ctrl + F to open file", ConsoleColor.Green);
            Console.SetCursorPosition((Console.WindowWidth - "Siv Text editor by Nevixity".Length) / 2, 5);
            Console.WriteLine("Siv Text editor by Nevixity");
            Console.SetCursorPosition((Console.WindowWidth - "Inspired by ziv (Winksplorer)".Length) / 2, 6);
            Console.WriteLine("Inspired by ziv (Winksplorer)");

            Console.SetCursorPosition((Console.WindowWidth - "Press any key to enter text editor...".Length) / 2, 15);
            Console.WriteLine("Press any key to enter text editor...");
            ConsoleKeyInfo ck = Console.ReadKey();
            if((ck.Modifiers == ConsoleModifiers.Control) && ck.Key == ConsoleKey.F)
            {
                Console.Clear();
                Console.Write("Enter file path : ");
                string? path = Console.ReadLine();
                if(path == null)
                {
                    Console.WriteLine("Path is null.");
                    Environment.Exit(0);
                }
                else
                {
                    try
                    {
                        textCanvas.textLines = File.ReadAllLines(path);
                        yTextLines = textCanvas.textLines.Length;
                        ReadWriteMode();
                    }
                    catch
                    {
                        Console.WriteLine("Invalid path.");
                        Environment.Exit(0);
                    }
                }
            }
            else
            {
                ReadWriteMode();
            }
        }

        private static void ReadWriteMode()
        {
            Console.Clear();
            while(true)
            {
                Console.Clear();
                Other.ConsoleFunction.PrintTopBar($"Siv Text editor | {fileName} | {textCanvas.currentTextMode.ToString()}", ConsoleColor.Green);
                if(textCanvas.currentTextMode == textMode.Write)
                {
                    textCanvas.Render();

                    string bufferText = ConsoleReadLine.ReadLine(textCanvas.inputConfig);
                    if(bufferText == "command")
                    {
                        textCanvas.currentTextMode = textMode.Command;
                        Console.SetCursorPosition(0, Console.WindowHeight);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        string cmd = ConsoleReadLine.ReadLine(textCanvas.inputConfig);
                        if(cmd == "sv")
                        {
                            SaveMenu();
                        }
                        else if(cmd == "setfn")
                        {
                            Console.Clear();
                            Console.Write("Enter new file name(Including file extension) : ");
                            fileName = Console.ReadLine();
                            Console.Clear();
                        }
                        else if(cmd == "setfp")
                        {
                            Console.Clear();
                            Console.Write("Enter new file path : ");
                            fileName = Console.ReadLine();
                            Console.Clear();
                        }
                        else if(cmd == "q")
                        {
                            Console.Clear();
                            Console.WriteLine("File exitted without saving 👍");
                            Environment.Exit(0);
                        }
                        else if(cmd == "rd")
                        {
                            textCanvas.currentTextMode = textMode.Read;
                        }
                    }
                    else
                    {
                        Array.Resize(ref textCanvas.textLines, textCanvas.textLines.Length + 1);
                        textCanvas.textLines[yTextLines] = bufferText;
                        yTextLines++;
                    }
                }
                else if(textCanvas.currentTextMode == textMode.Read)
                {
                    textCanvas.Render();
                    ConsoleKeyInfo ck = Console.ReadKey();
                    if(ck.Key == ConsoleKey.Escape)
                    {
                        textCanvas.currentTextMode = textMode.Write;
                    }
                }
            }
        }


        private static void SaveMenu()
        {
            Console.Clear();
            string[] option = new string[]
            {
                "Yes",
                "Change save location",
                "Exit"
            };
            int pointer = 0;

            while(true)
            {
                Console.Clear();
                Console.SetCursorPosition((Console.WindowWidth - $"Save file in {filePath}?".Length) / 2, 15);
                Console.WriteLine($"Save file in {filePath}?\n");
                for(int i = 0; i < option.Length; i++)
                {
                    if(i == pointer)
                    {
                        Console.WriteLine($"- {option[i]} -");
                    }
                    else
                    {
                        Console.WriteLine(option[i]);
                    }
                }
                ConsoleKeyInfo ck = Console.ReadKey();
                if(ck.Key == ConsoleKey.UpArrow)
                {
                    if(pointer != 0)
                    {
                        pointer--;
                    }
                }
                else if(ck.Key == ConsoleKey.DownArrow)
                {
                    if(pointer != option.Length - 1)
                    {
                        pointer++;
                    }
                }
                else if(ck.Key == ConsoleKey.Enter)
                {
                    if(pointer == 0)
                    {
                        try
                        {
                            File.WriteAllLines(filePath, textCanvas.textLines);
                            break;
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine($"{ex}");
                            Console.ReadKey();
                        }
                    }
                    else if (pointer == 1)
                    {
                        repeat:
                        Console.Write("\nEnter a new file path : ");
                        filePath = Console.ReadLine();
                        if(filePath == "" || filePath == null)
                        {
                            Console.WriteLine("File path is null!");
                            goto repeat;
                        }
                        else
                        {
                            try
                            {
                                File.WriteAllLines(filePath, textCanvas.textLines);
                                break;
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine($"{ex}");
                            }
                        }
                    }
                    else if(pointer == 2)
                    {
                        break;
                    }
                }
            }
        }
    }
}