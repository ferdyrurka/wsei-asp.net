using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wsei_asp.net.Util
{
    public static class TruncateString
    {
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}
