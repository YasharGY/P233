using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StaticStruct
{
    static class Extension
    {
        public static bool Match(this string str,string pattern)
        {
            return Regex.IsMatch(str, pattern);
        }

        public static double Power(this int n,int pow)
        {
            return Math.Pow(n, pow);
        }
    }
}
