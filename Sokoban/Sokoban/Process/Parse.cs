using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Parse
    {

        public static List<char[]> FileToCharArray(string filename)
        {
            List<char[]> lines = new List<char[]>();
            foreach (string line in File.ReadLines(filename))
            {
                lines.Append(line.ToCharArray());
            }
            return lines;
            //char[] char_array = lines.ToArray();
        }
    }
}