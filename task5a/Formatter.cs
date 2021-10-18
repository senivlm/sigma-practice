using System;
using System.Text.RegularExpressions;

namespace sigma_t5
{
    static class Formatter
    {
        public static string AngleBrackets(string input, string toReplace = "#")
        {
            Regex regex = new Regex(Regex.Escape("#"));
            int occurances = input.Split('#').Length - 1;
            return regex.Replace(input, "<", occurances / 2).Replace('#', '>');
        }
    }
}
