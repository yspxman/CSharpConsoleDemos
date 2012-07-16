using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PatternExamples
{
    class Utility
    {
        public  const string dotline = "--------------";
        public static string HeaderString(string PatternName)
        {
            return dotline + PatternName + dotline;
        }
    }
}
