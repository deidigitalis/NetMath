using System;
using System.Globalization;

namespace NetMath.Core
{
    /// <summary>
    /// An interval could be open and closed or combination of both at either
    /// end.
    /// </summary>
    public enum IntervalType
    {
        Closed = 0,
        Opened = 1
    }

    /// <summary>
    /// Numeric interval
    /// </summary>
    /// <typeparam name="T">Type of the interval</typeparam>
    public class Interval<T> where T : struct, IComparable
    {
        private const char ClosedLowerSymbol = '[';
        private const char ClosedUppersymbol = ']';
        private const char OpenedLowerSymbol = '(';
        private const char OpenedUpperSymbol = ')';

        /// <summary>
        /// Lower bound
        /// </summary>
        public T LowerBound { get; private set; }

        /// <summary>
        /// Lower bound type
        /// </summary>
        public IntervalType LowerBoundIntervalType { get; private set; }

        /// <summary>
        /// Upper bound
        /// </summary>
        public T UpperBound { get; private set; }

        /// <summary>
        /// Upper bound type
        /// </summary>
        public IntervalType UpperBoundIntervalType { get; private set; }

        public Interval(
            T lowerbound,
            T upperbound,
            IntervalType lowerboundIntervalType,
            IntervalType upperboundIntervalType)
        {
            if (lowerbound.CompareTo(upperbound) > 0)
                throw new InvalidOperationException("The lower bound has to be lower than rge upper bound.");

            LowerBound = lowerbound;
            UpperBound = upperbound;
            LowerBoundIntervalType = lowerboundIntervalType;
            UpperBoundIntervalType = upperboundIntervalType;
        }

        public override string ToString()
        {
            return ToString(CultureInfo.CurrentCulture);
        }

        public string ToString(IFormatProvider provider)
        {
            char lowerSymbol = LowerBoundIntervalType == IntervalType.Opened ? OpenedLowerSymbol : ClosedLowerSymbol;
            char upperSymbol = UpperBoundIntervalType == IntervalType.Opened ? OpenedUpperSymbol : ClosedUppersymbol;
            return string.Format(provider, "{0}{1},{2}{3}", lowerSymbol, LowerBound, UpperBound, upperSymbol);
        }
    }
}