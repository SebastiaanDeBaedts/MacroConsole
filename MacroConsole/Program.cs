using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

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
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(macro.keyPress + "\t" + macro.description);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("you have no macros");
            }
            Console.WriteLine("Type A to add a macro, E to edit a macro, R to remove a macro");
            switch (Console.ReadKey().KeyChar)
            {
                case 'A':
                    Console.WriteLine("which key will execute the macro?");
                    string key = Console.ReadKey().ToString();
                    Console.WriteLine("WHich type of macro? 1 for google, 2 for executing powershellscripts, 3 for executing powershell scripts, 4 for booting a program.");
                    int type = Convert.ToInt16(Console.ReadLine());
                    Console.WriteLine("Path to the URL/program/script?");
                    string path = Console.ReadLine();
                    Console.WriteLine("Description?");
                    string description = Console.ReadLine();
                    Macro m = new Macro(key,type, path, description);
                    list.macroList.Add(m);
                    list.WriteMacros();
                    list.ReadMacros();
                    break;
                case 'E':
                    Console.WriteLine("for which key would you like to edit the macro?");
                    string keyToEdit = Console.ReadKey().ToString();
                    
                    for (int i = 0; i < list.macroList.Count; i++)
                    {
                        if (list.macroList.ElementAt(i).keyPress == keyToEdit)
                        {
                            Console.WriteLine("Which type of macro? 1 for google, 2 for executing powershellscripts, 3 for executing powershell scripts, 4 for booting a program.");
                            int typeEdit = Convert.ToInt16(Console.ReadLine());
                            Console.WriteLine("Path to the URL/program/script?");
                            string pathEdit = Console.ReadLine();
                            Console.WriteLine("Description?");
                            string descriptionEdit = Console.ReadLine();
                            list.macroList.ElementAt(i).typeOfMacro = typeEdit;
                            list.macroList.ElementAt(i).pathOrURL = pathEdit;
                            list.macroList.ElementAt(i).description = descriptionEdit;
                            list.ReadMacros();
                            break;
                        }
                    }
                    break;
                case 'R':
                    Console.WriteLine("for which key would you like to remove the macro?");
                    var keyToRemove = Console.ReadKey().ToString();
                    for (int i = 0; i < list.macroList.Count; i++)
                    {
                        if (list.macroList.ElementAt(i).keyPress == keyToRemove)
                        {
                            list.macroList.RemoveAt(i);
                            list.ReadMacros();
                            break;
                        }
                    }
                    break;                
                default:
                    break;
            }
            Console.ReadLine();
            
            
        }
    }
}
