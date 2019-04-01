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
            this.ReadMacros();
        }

        public void ReadMacros()
        {
            //path = "MacroList.txt";           
            // This text is added only once to the file.
            macroList = new List<Macro>();
            if (File.Exists(path))
            {
                string line;
                System.IO.StreamReader file = new System.IO.StreamReader(path);
                while ((line = file.ReadLine()) != null)
                {
                    string[] lines = line.Split(",");
                    macroList.Add(new Macro(lines[0], Convert.ToInt16(lines[1]), lines[2], lines[3]));
                }
                file.Close();
            }
        }

        public void WriteMacros()
        {            
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter macroFile = File.CreateText(path))
                {
                    foreach (var item in macroList)
                    {
                        macroFile.WriteLine(item.keyPress + "~" + item.typeOfMacro + "~" + item.pathOrURL + "~" + item.description);
                    }
                    
                }
            }
        }
        public List<Macro> macroList { get; set; }
        public string path { get; set; }

    }
}

