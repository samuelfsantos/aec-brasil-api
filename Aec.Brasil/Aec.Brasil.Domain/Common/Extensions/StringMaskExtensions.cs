using System.Text.RegularExpressions;

namespace Aec.Brasil.Domain.Common.Extensions
{
    public static class StringMaskExtensions
    {
        public static string WithoutMaskToString(this string e)
        {
            if (!string.IsNullOrWhiteSpace(e)) {
                return Regex.Replace(e, "[^0-9a-zA-Z]+", "");
            }
            return e;
        }
    }
}
