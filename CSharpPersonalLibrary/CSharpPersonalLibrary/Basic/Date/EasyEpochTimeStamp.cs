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
        /// Converts a Epoch Time value to DateTime. 
        /// </summary>
        /// <param name="epochSeconds">Epoch Time value in seconds. Range between -62135596800 and 253402300799.</param>
        /// <returns>A UTC DateTime for the correspondent epochSeconds</returns>
        /// <exception cref="ArgumentOutOfRangeException">The epochSeconds param is out of range between -62135596800 and 253402300799</exception>
        public static DateTime ConvertEpochToDateTime(long epochSeconds)
        {
            return GetEpochTimeZero().AddSeconds(epochSeconds); 
        }

        /// <summary>
        /// Convert a DateTime to the Epoch Time valueT
        /// </summary>
        /// <param name="dateTime">A DateTime value to be converted</param>
        /// <returns>A long value with the Epoch Time value in seconds</returns>
        public static long ConvertDateTimeToEpoch(DateTime dateTime)
        {
              
            TimeSpan dif = dateTime.ToUniversalTime() - GetEpochTimeZero();
            dif = dif.Subtract(new TimeSpan(dif.Ticks%10000000));  //This is because if it has at least 1 tick more, it will round up the seconds.
            
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
