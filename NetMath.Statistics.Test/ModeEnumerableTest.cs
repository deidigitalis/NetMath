using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetMath.Core;
using NetMath.Statistics.Mode;
using System.Collections.Generic;

namespace NetMath.Statistics.Test
{
    [TestClass]
    public class ModeEnumerableTest
    {
        [TestMethod]
        public void TestMode()
        {
            var distribution = new List<double> { 2, 2, 3, 3, 3, 3, 5, 6, 7 };
            double mo = distribution.Mode();
            Assert.AreEqual(3, mo);
        }

        [TestMethod]
        public void TestModeInTable()
        {
            var distribution = new List<ValueFrecuencyPair>
            {
                new ValueFrecuencyPair(1, 34),
                new ValueFrecuencyPair(2, 36),
                new ValueFrecuencyPair(3, 45),
                new ValueFrecuencyPair(4, 22),
                new ValueFrecuencyPair(5, 17),
            };

            ValueFrecuencyPair mo = distribution.Mode();
            Assert.AreEqual(3, mo.Value);
        }

        [TestMethod]
        public void TestModeInTableContinuos()
        {
            var distribution = new List<IntervalFrecuencyPair>
            {
                new IntervalFrecuencyPair(new Interval<double>(140,160, IntervalType.Closed, IntervalType.Opened), 30),
                new IntervalFrecuencyPair(new Interval<double>(160,170, IntervalType.Closed, IntervalType.Opened), 22),
                new IntervalFrecuencyPair(new Interval<double>(170,180, IntervalType.Closed, IntervalType.Opened), 20),
                new IntervalFrecuencyPair(new Interval<double>(180,190, IntervalType.Closed, IntervalType.Opened), 18),
                new IntervalFrecuencyPair(new Interval<double>(190,200, IntervalType.Closed, IntervalType.Opened), 10)
            };

            double mo = distribution.Mode();
            Assert.AreEqual(167.777, mo, 1e-3);
        }
    }
}