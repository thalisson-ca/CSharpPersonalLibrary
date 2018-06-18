using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPersonalLibrary.Basic.Date
{
    public class EasyEpochTimeStamp
    {
        /// <summary>
        /// Converts a Epoch Time value to DateTime
        /// </summary>
        /// <param name="epochSeconds">Epoch Time value in seconds</param>
        /// <returns>A UTC DateTime for the correspondent epochSeconds</returns>
        public static DateTime ConvertEpochToDateTime(long epochSeconds)
        {
            return GetEpochTimeZero().AddSeconds(epochSeconds);

        }

        /// <summary>
        /// Convert a DateTime to the Epoch Time value
        /// </summary>
        /// <param name="dateTime">A DateTime value to be converted</param>
        /// <returns>A long value with the Epoch Time value</returns>
        public static long ConvertDateTimeToEpoch(DateTime dateTime)
        {
            TimeSpan dif = dateTime.ToUniversalTime() - GetEpochTimeZero();
            return (long)dif.TotalSeconds;
        }

        /// <summary>
        /// Get a DateTime value with the 0 Epoch Time moment
        /// </summary>
        /// <returns></returns>
        public static DateTime GetEpochTimeZero()
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        }
    }
}
