using Sokoban.Properties;
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
            String[] lines = filename.Split(new String[] { Environment.NewLine }, StringSplitOptions.None);
            return lines;
            
        }
    }
}