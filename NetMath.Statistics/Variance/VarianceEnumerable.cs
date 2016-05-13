using System;
using System.Collections.Generic;
using System.Linq;

namespace NetMath.Statistics.Variance
{
    public static class VarianceEnumerable
    {
        /// <summary>
        /// Standard Deviation
        /// </summary>
        /// <param name="sortedData">Sorted data</param>
        public static double StandardDeviation(this IList<double> sortedData)
        {
            return Math.Sqrt(sortedData.Variance());
        }

        /// <summary>
        /// Standard Deviation
        /// </summary>
        /// <param name="distribution">Sorted data</param>
        public static double StandardDeviation(this IList<ValueFrecuencyPair> distribution)
        {
            double variance = Variance(distribution);
            return Math.Sqrt(variance);
        }

        /// <summary>
        /// Variance
        /// </summary>
        /// <param name="distribution">Sorted data</param>
        public static double Variance(this IList<double> distribution)
        {
            return Variance(distribution.ConvertToValueFrecuencyPair());
        }

        /// <summary>
        /// Variance
        /// </summary>
        /// <param name="distribution">Sorted data</param>
        public static double Variance(this IList<ValueFrecuencyPair> distribution)
        {
            if (distribution == null) throw new ArgumentNullException(nameof(distribution));

            if (distribution.Count == 0)
                throw new InvalidOperationException("The distribution has to contain at least one value.");

            int n = distribution.Sum(x => x.Frecuency);
            double avg = distribution.Sum(x => x.Value * x.Frecuency) / n;
            return distribution.Sum(x => x.Frecuency * x.Value * x.Value) / n - avg * avg;
        }
    }
}