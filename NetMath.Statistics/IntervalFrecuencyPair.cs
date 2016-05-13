using NetMath.Core;

namespace NetMath.Statistics
{
    /// <summary>
    /// Interval of a value (read only) and its frecuency (editable)
    /// </summary>
    public class IntervalFrecuencyPair
    {
        /// <summary>
        /// Frecuency of the given value
        /// </summary>
        public int Frecuency { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public Interval<double> Value { get; private set; }

        public IntervalFrecuencyPair(Interval<double> value, int frecuency)
        {
            Value = value;
            Frecuency = frecuency;
        }
    }
}