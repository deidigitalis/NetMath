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
        public static double Decile(this IEnumerable<double> sortedData, int i)
        {
            return Quantile(sortedData, i, 10);
        }

        /// <summary>
        /// Median
        /// </summary>
        /// <param name="sortedData">Sorted data</param>
        public static double Median(this IEnumerable<double> sortedData)
        {
            return Quantile(sortedData, 1, 2);
        }

        /// <summary>
        /// Percentile
        /// </summary>
        /// <param name="sortedData">Sorted data</param>
        /// <param name="i">Percentile value</param>
        public static double Percentile(this IEnumerable<double> sortedData, int i)
        {
            return Quantile(sortedData, i, 100);
        }

        /// <summary>
        /// Quartile
        /// </summary>
        /// <param name="sortedData">Sorted data</param>
        /// <param name="i">Index</param>
        /// <param name="parts">Number of parts</param>
        /// <see cref="http://support.microsoft.com/en-us/kb/214072"/>
        public static double Quantile(this IEnumerable<double> sortedData, int i, int parts)
        {
            double n, f, l, r;
            int k;

            if (sortedData == null) throw new ArgumentNullException(nameof(sortedData));

            if (parts < 2) throw new ArgumentOutOfRangeException(nameof(parts));

            if (i < 0 || i > parts) throw new ArgumentOutOfRangeException(nameof(i));

            if (i == 0)
                return sortedData.First();

            if (i == parts)
                return sortedData.Last();

            var distribution = sortedData as IList<double> ?? sortedData.ToList();

            n = distribution.Count;

            k = (int)Math.Truncate((i / (double)parts) * (n - 1d));
            f = (i / (double)parts) * (n - 1d) - k;

            l = distribution[k];
            r = distribution[k + 1];

            return l + (f * (r - l));
        }

        /// <summary>
        /// Quartile
        /// </summary>
        /// <param name="sortedData">Sorted data</param>
        /// <param name="i">Quartile value</param>
        /// <see cref="http://support.microsoft.com/en-us/kb/214072"/>
        public static double Quartile(this IEnumerable<double> sortedData, int i)
        {
            return Quantile(sortedData, i, 4);
        }
    }
}