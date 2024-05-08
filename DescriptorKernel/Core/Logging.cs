
using System;
using System.Diagnostics;
using Mosa.Kernel.BareMetal;
using Mosa.Runtime.Plug;

namespace DescriptorKernel.Core;

public static class Logging {
    public static int LoggingLevel = 0;

    public static void Debug(string location, string message) {
        if (LoggingLevel > 0) return;
        
        Console.WriteLine($"[{Colour.Foreground.Grey}Debug{Colour.Foreground.Reset}] [{Colour.Foreground.Grey}{location}{Colour.Foreground.Reset}] {message}");
    }

    public static void Info(string location, string message) {
        if (LoggingLevel > 1) return;
        Console.WriteLine($"[{Colour.Foreground.Green}Info{Colour.Foreground.Reset}] [{Colour.Foreground.Grey}{location}{Colour.Foreground.Reset}] {message}");
    }

    public static void Warn(string location, string message) {
        if (LoggingLevel > 2) return;
        Console.WriteLine($"[{Colour.Foreground.Yellow}Warn{Colour.Foreground.Reset}] [{Colour.Foreground.Grey}{location}{Colour.Foreground.Reset}] {message}");
    }

    public static void Error(string location, string message) {
        if (LoggingLevel > 3) return;
        Console.WriteLine($"[{Colour.Foreground.Red}Error{Colour.Foreground.Reset}] [{Colour.Foreground.Grey}{location}{Colour.Foreground.Reset}] {message}");
    }
}
