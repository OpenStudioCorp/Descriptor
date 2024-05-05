using Cosmos.Debug.Kernel;
using Cosmos.Debug;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sys = Cosmos.System;
namespace Descriptor
{
    public class Welcome
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
            Console.WriteLine(text);
        }
        
        public static void Konsole()
        {
            var input = Console.ReadLine();
            switch (input)
            {
                case "help":
                    PrintS("help: print's the help text your reading");
                    PrintS("exit: exit the program");
                    PrintS("Shutdown: shutdown the computer");
                    PrintS("Restart: restart the computer");

                    break;
                
                case "exit":
                    PrintS("Exting");
                    PrintS("Thank you for using Descriptor");
                    PrintS("by OpenStudio");
                    
                    break;
                case "shutdown":
                    Sys.Power.Shutdown(); // shutdown is supported
                    break;
                case "restart":
                    Sys.Power.Reboot(); // restart too
                    break;
                default:
                    Console.WriteLine("invalid input: " + input);
                    break;
            }
            
        }
        public static void Kwelcome() 
        {
            PrintS("########################");
            PrintS("####---Descriptor---####");
            PrintS("########################");
            PrintS("########--V1.0--########");
            PrintS("########################");
            PrintS("########################");
            PrintS("#####--Created by--#####");
            PrintS("#####--OpenStudio--#####");
            PrintS("########################");
        }
    }
}
