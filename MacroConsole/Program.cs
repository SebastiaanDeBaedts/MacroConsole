using System;
using System.Collections.Generic;
using System.Drawing;

namespace MacroConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Macro Console";
            /*ConsoleColor backGround = Console.BackgroundColor;
            ConsoleColor foreground = Console.ForegroundColor;*/
            List<Macro> listOfCustomMacros = new List<Macro>();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.WriteLine("MacroConsole");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Current Macros:");
            MacroList list = new MacroList(@".\MacroList.txt");
            if (list.macroList.Count != 0)
            {
                foreach (Macro macro in list.macroList)
                {
                    int r = 225;
                    int g = 255;
                    int b = 250;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(macro.keyPress + "\t" + macro.description);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("you have no macros");
            }
           
            Console.ReadLine();
            
            
        }
    }
}
