using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Parse
    {

        public static string[] FileToStringArray(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            return lines;
            
        }
    }
}