using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMessageProcessing.Library.Extensions {
    /// <summary>
    /// Short hand for multiple OR clause
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="item"></param>
    /// <param name="items"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static class GenericExtension {
        public static bool In<T>(this T item, params T[] items)
        {
            if (items == null)
                throw new ArgumentNullException(nameof(items));

            return items.Contains(item);
        }
    }
}
