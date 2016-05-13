using System;
using System.Collections.Generic;
using System.Linq;

namespace NetMath.Statistics
{
    /// <summary>
    /// Pair of a value (read only) and its frecuency (editable)
    /// </summary>
    public class ValueFrecuencyPair
    {
        /// <summary>
        /// Frecuency of the given value
        /// </summary>
        public int Frecuency { get; private set; }

        /// <summary>
        /// Value
        /// </summary>
        public double Value { get; private set; }

        public ValueFrecuencyPair(double value, int frecuency)
        {
            Value = value;
            Frecuency = frecuency;
        }

        /// <summary>
        /// Converts a distribution of numbers in a collection of ValueFrecuencyPair.
        /// </summary>
        /// <param name="distribution">Sorted distribution (from lowest to highest)</param>
        /// <returns></returns>
        public static IEnumerable<ValueFrecuencyPair> Convert(IEnumerable<double> distribution)
        {
            if (distribution == null) throw new ArgumentNullException(nameof(distribution));

            var collection = distribution as IList<double> ?? distribution.ToList();

            var frecuencies = new List<ValueFrecuencyPair>();
            foreach (var v in collection)
            {
                var pair = frecuencies.FirstOrDefault(x => Math.Abs(x.Value - v) < 1e-6);

                if (pair == null)
                    frecuencies.Add(new ValueFrecuencyPair(v, 1));
                else
                    pair.Frecuency++;
            }

            return frecuencies;
        }
    }
}