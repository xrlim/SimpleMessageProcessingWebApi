using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessageProcessing.Library.Extensions {
    public static class StringExtension {

        private static string Iso8601DateTimeFormat = "yyyy-MM-dd HH:mm";

        /// <summary>
        /// Shorthand for IsNullOrEmpty
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string self)
        {
            return string.IsNullOrEmpty(self);
        }

        /// <summary>
        /// Shorthand for IsNullOrWhiteSpace
        /// </summary>
        /// <param name="self"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string self)
        {
            return string.IsNullOrWhiteSpace(self);
        }

        /// <summary>
        /// The C# Contains() method is used to return a value indicating whether the specified substring occurs within this string or not. If the specified substring is found in this string, it returns true otherwise false.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="toCheck"></param>
        /// <param name="comp"></param>
        /// <returns></returns>
        public static bool Contains(this string source, string toCheck, StringComparison comp)
        {
            return source.IndexOf(toCheck, comp) >= 0;
        }

        /// <summary>
        /// Returns a string containing a specified number of characters from the left side of a string.
        /// </summary>
        /// <param name="maxLength">
        /// Required. Integer expression. Numeric expression indicating how many characters to return. If 0, a zero-length string ("") is returned. If greater than or equal to the number of characters in str, the entire string is returned.
        /// </param>
        /// <returns>A string containing a specified number of characters from the left side of a string.</returns>
        public static string Left(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            maxLength = Math.Abs(maxLength);

            return (value.Length <= maxLength
                   ? value
                   : value.Substring(0, maxLength)
                   );
        }

        /// <summary>
        /// Returns a string containing a specified number of characters from the right side of a string.
        /// </summary>
        /// <param name="maxLength">
        /// Required. Integer expression. Numeric expression indicating how many characters to return. If 0, a zero-length string ("") is returned. If greater than or equal to the number of characters in str, the entire string is returned.
        /// </param>
        /// <returns>A string containing a specified number of characters from the right side of a string.</returns>
        public static string Right(this string value, int iMaxLength)
        {
            //Check if the value is valid
            if (string.IsNullOrEmpty(value))
            {
                //Set valid empty string as string could be null
                value = string.Empty;
            }
            else if (value.Length > iMaxLength)
            {
                //Make the string no longer than the max length
                value = value.Substring(value.Length - iMaxLength, iMaxLength);
            }

            //Return the string
            return value;
        }

        /// <summary>
        /// To Iso 8086 format 
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static string ToIso8601DateTime(this DateTime datetime)
        {
            return datetime.ToString(Iso8601DateTimeFormat);
        }

    }
}
