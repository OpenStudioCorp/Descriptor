using System;

namespace siv.Other
{
    public static class ConsoleFunction
    {
        public static int pos = 0;
        public static void PrintTopBar(string Text, ConsoleColor topBarColor)
        {
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = topBarColor;
            Console.Write(Text);
            for(int i = 0; i < Console.BufferWidth - Text.Length; i++)
            {
                Console.Write(' ');
            }
            Console.ResetColor();
        }

        public static void PrintBottomBar(string Text, ConsoleColor bottomBarColor)
        {
            Console.SetCursorPosition(0, Console.WindowHeight);
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = bottomBarColor;
            Console.Write(Text);
            for(int i = 0; i < Console.BufferWidth - Text.Length; i++)
            {
                Console.Write(' ');
            }
        }
    }
}