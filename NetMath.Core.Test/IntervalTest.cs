using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;

namespace NetMath.Core.Test
{
    [TestClass]
    public class IntervalTest
    {
        [TestMethod]
        public void TestIntervalDoubleClosedClosed()
        {
            var interval = new Interval<int>(10, 100, IntervalType.Closed, IntervalType.Closed);
            Assert.AreEqual(IntervalType.Closed, interval.LowerBoundIntervalType);
            Assert.AreEqual(IntervalType.Closed, interval.UpperBoundIntervalType);
            Assert.AreEqual("[10,100]", interval.ToString(CultureInfo.InvariantCulture));
        }

        [TestMethod]
        public void TestIntervalDoubleClosedOpened()
        {
            var interval = new Interval<int>(10, 100, IntervalType.Closed, IntervalType.Opened);
            Assert.AreEqual(IntervalType.Closed, interval.LowerBoundIntervalType);
            Assert.AreEqual(IntervalType.Opened, interval.UpperBoundIntervalType);
            Assert.AreEqual("[10,100)", interval.ToString(CultureInfo.InvariantCulture));
        }

        [TestMethod]
        public void TestIntervalDoubleOpenedClose()
        {
            var interval = new Interval<int>(10, 100, IntervalType.Opened, IntervalType.Closed);
            Assert.AreEqual(IntervalType.Opened, interval.LowerBoundIntervalType);
            Assert.AreEqual(IntervalType.Closed, interval.UpperBoundIntervalType);
            Assert.AreEqual("(10,100]", interval.ToString(CultureInfo.InvariantCulture));
        }

        [TestMethod]
        public void TestIntervalDoubleOpenedOpened()
        {
            var interval = new Interval<int>(10, 100, IntervalType.Opened, IntervalType.Opened);
            Assert.AreEqual(IntervalType.Opened, interval.LowerBoundIntervalType);
            Assert.AreEqual(IntervalType.Opened, interval.UpperBoundIntervalType);
            Assert.AreEqual("(10,100)", interval.ToString(CultureInfo.InvariantCulture));
        }
    }
}