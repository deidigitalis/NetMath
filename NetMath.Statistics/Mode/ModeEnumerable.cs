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
        public static double Mode(this IEnumerable<double> distribution)
        {
            if (distribution == null) throw new ArgumentNullException(nameof(distribution));

            var collection = distribution as IList<double> ?? distribution.ToList();

            if (collection.Count == 0)
                throw new InvalidOperationException("The distribution has to contain at least one value.");

            var frecuencies = new List<ValueFrecuencyPair>();
            foreach (var v in collection)
            {
                var pair = frecuencies.FirstOrDefault(x => Math.Abs(x.Value - v) < 1e-6);

                if (pair == null)
                    frecuencies.Add(new ValueFrecuencyPair(v, 1));
                else
                    pair.Frecuency++;
            }

            ValueFrecuencyPair maximumFrecuency = frecuencies.Mode();

            return maximumFrecuency.Value;
        }

        /// <summary>
        /// Mode for discrete distribution
        /// </summary>
        /// <param name="distribution">Sorted distribution (from lowest to highest)</param>
        /// <returns>Mode</returns>
        public static ValueFrecuencyPair Mode(this IEnumerable<ValueFrecuencyPair> distribution)
        {
            if (distribution == null) throw new ArgumentNullException(nameof(distribution));

            var collection = distribution as IList<ValueFrecuencyPair> ?? distribution.ToList();

            if (collection.Count == 0)
                throw new InvalidOperationException("The distribution has to contain at least one value.");

            ValueFrecuencyPair maximumFrecuency = collection.First();
            foreach (var pair in collection.Skip(1))
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
        public static double Mode(this IEnumerable<IntervalFrecuencyPair> distribution)
        {
            if (distribution == null) throw new ArgumentNullException(nameof(distribution));

            var collection = distribution as IList<IntervalFrecuencyPair> ?? distribution.ToList();

            if (collection.Count == 0)
                throw new InvalidOperationException("The distribution has to contain at least one value.");

            var h = collection.Select(x => x.Frecuency / Math.Abs(x.Value.UpperBound - x.Value.LowerBound)).ToList();

            int indexMaxH = 0;
            double maxH = h[indexMaxH];
            for (int index = 1, count = collection.Count; index < count; index++)
            {
                double value = h[index];
                if (maxH < value)
                {
                    indexMaxH = index;
                    maxH = value;
                }
            }

            // ReSharper disable InconsistentNaming
            double ei_m1 = collection[indexMaxH].Value.LowerBound;
            double hi = h[indexMaxH];
            double hi_m1 = h[indexMaxH - 1];
            double hi_p1 = h[indexMaxH + 1];
            double ai = Math.Abs(collection[indexMaxH].Value.UpperBound - collection[indexMaxH].Value.LowerBound);
            // ReSharper restore InconsistentNaming

            return ei_m1 + (hi - hi_m1) / ((hi - hi_m1) + (hi - hi_p1)) * ai;
        }
    }
}