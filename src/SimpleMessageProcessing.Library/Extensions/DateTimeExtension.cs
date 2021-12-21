using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessageProcessing.Library.Extensions {
    public static class DateTimeExtension {

        /// <summary>
        /// Convert Unix Epoch String to Date Time
        /// </summary>
        /// <param name="epochSeconds"></param>
        /// <returns></returns>
        public static DateTime FromEpochStringToDateTime(this string epochSeconds)
        {
            if (epochSeconds.IsNullOrWhiteSpace())
            {
                return DateTime.MinValue;
            }

            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(int.Parse(epochSeconds));
            return dateTimeOffset.DateTime;
        }
    }
}
