using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OnePos.Framework.Extensions
{
    public static class StringExtensions
    {
        public static string NewLineToBreak(this string input)
        {
            var regEx = new Regex(@"[\n|\r]+");
            return regEx.Replace(input, "<br />");
        }
    }
}
