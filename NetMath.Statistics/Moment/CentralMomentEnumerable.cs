using System;
using System.Collections.Generic;
using System.Linq;

namespace NetMath.Statistics.Moment
{
    public static class CentralMomentEnumerable
    {
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
            if (distribution == null) throw new ArgumentNullException(nameof(distribution));

            if (r <= 0) throw new ArgumentOutOfRangeException(nameof(r));

            double avg = distribution.Average();

            var table = distribution.ConvertToValueFrecuencyPair();

            return table.Sum(x => x.Frecuency * Math.Pow(x.Value - avg, r)) / table.Sum(x => x.Frecuency);
        }
    }
}