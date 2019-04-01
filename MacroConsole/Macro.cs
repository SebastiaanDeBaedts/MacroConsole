using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MacroConsole
{
    class Macro
    {
        public Macro(string key, int type, string pathOrURL, string description)
        {
            this.keyPress = key;
            this.typeOfMacro = type;
            this.pathOrURL = pathOrURL;
            this.description = description;
        }
        public void WriteMacroToFile()
        {
            string path = File.ReadAllText(File.ReadAllText(@".\config.txt"));
            // This text is added only once to the file.
            if (!File.Exists(path))
            {
                // Create a file to write to.
                using (StreamWriter macroFile = File.CreateText(path))
                {
                    macroFile.WriteLine(keyPress + "~" + typeOfMacro + "~" + pathOrURL + "~" + description);
                }
            }
        }
        public string keyPress { get; set; }
        public string pathOrURL { get; set; }
        public string description { get; set; }
        public int typeOfMacro { get; set; }

    }
}
