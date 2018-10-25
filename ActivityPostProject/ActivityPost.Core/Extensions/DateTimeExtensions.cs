using System;
using System.Collections.Generic;
using System.Text;

namespace ActivityPost.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static long ToUnixTimeStamp(this DateTime date)
        {
            return (Int32)(date.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
        }
    }
}
