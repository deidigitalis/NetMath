using System;
using System.Collections.Generic;
using System.Linq;

namespace NetMath.Statistics.Mode
{
    public static class ModeEnumerable
    {
        /// <summary>
        /// Mode
        /// </summary>
        /// <param name="distribution">Sorted distribution (from lowest to highest)</param>
        public static double Mode(this IList<double> distribution)
        {
            var frecuencies = ValueFrecuencyPair.Convert(distribution);
            ValueFrecuencyPair maximumFrecuency = frecuencies.Mode();
            return maximumFrecuency.Value;
        }

        /// <summary>
        /// Mode for discrete distribution
        /// </summary>
        /// <param name="distribution">Sorted distribution (from lowest to highest)</param>
        /// <returns>Mode</returns>
        public static ValueFrecuencyPair Mode(this IList<ValueFrecuencyPair> distribution)
        {
            if (distribution == null) throw new ArgumentNullException(nameof(distribution));

            if (distribution.Count == 0)
                throw new InvalidOperationException("The distribution has to contain at least one value.");

            ValueFrecuencyPair maximumFrecuency = distribution.First();
            foreach (var pair in distribution.Skip(1))
            {
                if (maximumFrecuency.Frecuency < pair.Frecuency)
                    maximumFrecuency = pair;
            }

            return maximumFrecuency;
        }

        /// <summary>
        /// Mode for continuos distribution
        /// </summary>
        /// <param name="distribution">Sorted distribution (from lowest to highest)</param>
        /// <returns>Mode</returns>
        public static double Mode(this IList<IntervalFrecuencyPair> distribution)
        {
            if (distribution == null) throw new ArgumentNullException(nameof(distribution));

            if (distribution.Count == 0)
                throw new InvalidOperationException("The distribution has to contain at least one value.");

            var h = distribution.Select(x => x.Frecuency / Math.Abs(x.Value.UpperBound - x.Value.LowerBound)).ToList();

            int indexMaxH = 0;
            double maxH = h[indexMaxH];
            for (int index = 1, count = distribution.Count; index < count; index++)
            {
                double value = h[index];
                if (maxH < value)
                {
                    indexMaxH = index;
                    maxH = value;
                }
            }

            // ReSharper disable InconsistentNaming
            double ei_m1 = distribution[indexMaxH].Value.LowerBound;
            double hi = h[indexMaxH];
            double hi_m1 = h[indexMaxH - 1];
            double hi_p1 = h[indexMaxH + 1];
            double ai = Math.Abs(distribution[indexMaxH].Value.UpperBound - distribution[indexMaxH].Value.LowerBound);
            // ReSharper restore InconsistentNaming

            return ei_m1 + (hi - hi_m1) / ((hi - hi_m1) + (hi - hi_p1)) * ai;
        }
    }
}