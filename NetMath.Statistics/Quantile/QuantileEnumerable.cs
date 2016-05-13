using System;
using System.Collections.Generic;
using System.Linq;

namespace NetMath.Statistics.Quantile
{
    public static class QuantileEnumerable
    {
        /// <summary>
        /// Decile
        /// </summary>
        /// <param name="sortedData">Sorted data</param>
        /// <param name="i">Decile value</param>
        public static double Decile(this IList<double> sortedData, int i)
        {
            return Quantile(sortedData, i, 10);
        }

        /// <summary>
        /// Median
        /// </summary>
        /// <param name="sortedData">Sorted data</param>
        public static double Median(this IList<double> sortedData)
        {
            return Quantile(sortedData, 1, 2);
        }

        /// <summary>
        /// Percentile
        /// </summary>
        /// <param name="sortedData">Sorted data</param>
        /// <param name="i">Percentile value</param>
        public static double Percentile(this IList<double> sortedData, int i)
        {
            return Quantile(sortedData, i, 100);
        }

        /// <summary>
        /// Quartile
        /// </summary>
        /// <param name="distribution">Sorted data</param>
        /// <param name="i">Index</param>
        /// <param name="parts">Number of parts</param>
        /// <see cref="http://support.microsoft.com/en-us/kb/214072"/>
        public static double Quantile(this IList<double> distribution, int i, int parts)
        {
            if (distribution == null) throw new ArgumentNullException(nameof(distribution));

            if (parts < 2) throw new ArgumentOutOfRangeException(nameof(parts));

            if (i < 0 || i > parts) throw new ArgumentOutOfRangeException(nameof(i));

            if (i == 0)
                return distribution.First();

            if (i == parts)
                return distribution.Last();

            double n = distribution.Count;

            var k = (int)Math.Truncate((i / (double)parts) * (n - 1d));
            var f = (i / (double)parts) * (n - 1d) - k;

            var l = distribution[k];
            var r = distribution[k + 1];

            return l + (f * (r - l));
        }

        /// <summary>
        /// Quartile
        /// </summary>
        /// <param name="sortedData">Sorted data</param>
        /// <param name="i">Quartile value</param>
        /// <see cref="http://support.microsoft.com/en-us/kb/214072"/>
        public static double Quartile(this IList<double> sortedData, int i)
        {
            return Quantile(sortedData, i, 4);
        }
    }
}