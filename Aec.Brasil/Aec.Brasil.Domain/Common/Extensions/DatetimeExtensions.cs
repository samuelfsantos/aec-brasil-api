using System;

namespace Aec.Brasil.Domain.Common.Extensions
{
    public static class DatetimeExtensions
    {
        public static DateTime? ToDateTime(this string s)
        {
            DateTime dtr;
            var tryDtr = DateTime.TryParse(s, out dtr);
            return (tryDtr) ? dtr : new DateTime?();
        }

        public static DateTime ToDateTimeNotNull(this string s)
        {
            DateTime dtr;
            var tryDtr = DateTime.TryParse(s, out dtr);
            return (tryDtr) ? dtr : new DateTime();
        }
    }
}
