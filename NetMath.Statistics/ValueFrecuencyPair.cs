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
        public int Frecuency { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public double Value { get; private set; }

        public ValueFrecuencyPair(double value, int frecuency)
        {
            Value = value;
            Frecuency = frecuency;
        }
    }
}