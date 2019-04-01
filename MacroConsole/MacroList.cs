using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MacroConsole
{
    class MacroList
    {
               
        public MacroList(string path)
        {
            this.path = path;
            macroList = new List<Macro>();
            this.LoadMacros();
        }

        //fills list of macros from file
        public void LoadMacros()
        {
            //path = "MacroList.txt";           
            // This text is added only once to the file.
            macroList = new List<Macro>();
            if (File.Exists(path))
            {
                string line;
                                   
                        
                    string[] Alllines = File.ReadAllLines(path);
                    foreach (string linelocal in Alllines)
                    {
                        string[] linesSplit = linelocal.Split(",");
                        macroList.Add(new Macro(linesSplit[0], Convert.ToInt16(linesSplit[1]), linesSplit[2], linesSplit[3]));
                    }

                 
                
            }
        }        

        //writes all macros to file
        public void WriteMacros()
        {            
            // This text is added only once to the file.
            if (File.Exists(path))
            {
                
                File.AppendAllText(path, "");
                foreach (var item in macroList)
                {
                    File.AppendAllText(path, item.keyPress + "," + item.typeOfMacro + "," + item.pathOrURL + "," + item.description + Environment.NewLine);
                } 
            }
        }
        public List<Macro> macroList { get; set; }
        public string path { get; set; }

    }
}

