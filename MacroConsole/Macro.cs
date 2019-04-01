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
        
        public string keyPress { get; set; }
        public string pathOrURL { get; set; }
        public string description { get; set; }
        public int typeOfMacro { get; set; }

    }
}
