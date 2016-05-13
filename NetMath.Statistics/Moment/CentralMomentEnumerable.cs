using System;
using System.Collections.Generic;
using System.Linq;

namespace NetMath.Statistics.Moment
{
    public static class CentralMomentEnumerable
    {
        /// <summary>
        /// Bias function
        /// </summary>
        /// <param name="distribution">Sorted distribution</param>
        /// <returns>γ1</returns>
        public static double Bias(this IList<double> distribution)
        {
            if (distribution == null) throw new ArgumentNullException(nameof(distribution));

            var table = distribution.ConvertToValueFrecuencyPair();

            return Bias(table);
        }

        /// <summary>
        /// Bias function
        /// </summary>
        /// <param name="distribution">Sorted distribution</param>
        /// <returns>γ1</returns>
        public static double Bias(this IList<ValueFrecuencyPair> distribution)
        {
            if (distribution == null) throw new ArgumentNullException(nameof(distribution));

            double n = distribution.Sum(x => x.Frecuency);
            double avg = distribution.Sum(x => x.Frecuency * x.Value) / n;
            double μ2 = distribution.Sum(x => x.Frecuency * (x.Value - avg) * (x.Value - avg)) / n; // Variance
            double standardDeviation = Math.Sqrt(μ2);
            double μ3 = distribution.Sum(x => x.Frecuency * (x.Value - avg) * (x.Value - avg) * (x.Value - avg)) / n;
            return μ3 / (standardDeviation * standardDeviation * standardDeviation);
        }

        /// <summary>
        /// Central moment about the origin
        /// </summary>
        /// <param name="distribution">Sorted distribution</param>
        /// <param name="r">r-moment</param>
        /// <returns>m(r)</returns>
        public static double CentralMoment(this IList<double> distribution, int r)
        {
            if (distribution == null) throw new ArgumentNullException(nameof(distribution));

            if (r <= 0) throw new ArgumentOutOfRangeException(nameof(r));

            var table = distribution.ConvertToValueFrecuencyPair();
            return table.Sum(x => x.Frecuency * Math.Pow(x.Value, r)) / table.Sum(x => x.Frecuency);
        }

        /// <summary>
        /// Central moment about the airthmetic mean
        /// </summary>
        /// <param name="distribution">Sorted distribution</param>
        /// <param name="r">r-moment</param>
        /// <returns>μ(r)</returns>
        public static double CentralMomentAboutMean(this IList<double> distribution, int r)
        {
            if (r <= 0) throw new ArgumentOutOfRangeException(nameof(r));

            return CentralMomentAboutMean(distribution.ConvertToValueFrecuencyPair(), r);
        }

        /// <summary>
        /// Central moment about the airthmetic mean
        /// </summary>
        /// <param name="distribution">Sorted distribution</param>
        /// <param name="r">r-moment</param>
        /// <returns>μ(r)</returns>
        public static double CentralMomentAboutMean(this IList<ValueFrecuencyPair> distribution, int r)
        {
            if (distribution == null) throw new ArgumentNullException(nameof(distribution));

            double n = distribution.Sum(x => x.Frecuency);
            double avg = distribution.Sum(x => x.Frecuency * x.Value) / n;
            return distribution.Sum(x => x.Frecuency * Math.Pow(x.Value - avg, r)) / n;
        }

        /// <summary>
        /// Curtosis function
        /// </summary>
        /// <param name="distribution">Sorted distribution</param>
        /// <returns>γ1</returns>
        public static double Curtosis(this IList<double> distribution)
        {
            if (distribution == null) throw new ArgumentNullException(nameof(distribution));

            var table = distribution.ConvertToValueFrecuencyPair();

            return Curtosis(table);
        }

        /// <summary>
        /// Curtosis function
        /// </summary>
        /// <param name="distribution">Sorted distribution</param>
        /// <returns>γ1</returns>
        public static double Curtosis(IList<ValueFrecuencyPair> distribution)
        {
            if (distribution == null) throw new ArgumentNullException(nameof(distribution));

            double n = distribution.Sum(x => x.Frecuency);
            double avg = distribution.Sum(x => x.Frecuency * x.Value) / n;
            double μ2 = distribution.Sum(x => x.Frecuency * (x.Value - avg) * (x.Value - avg)) / n; // Variance
            double μ4 = distribution.Sum(x => x.Frecuency * (x.Value - avg) * (x.Value - avg) * (x.Value - avg) * (x.Value - avg)) / n;
            return μ4 / (μ2 * μ2) - 3d;
        }
    }
}