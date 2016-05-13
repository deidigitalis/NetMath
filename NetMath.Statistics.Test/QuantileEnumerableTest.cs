using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetMath.Statistics.Quantile;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetMath.Statistics.Test
{
    [TestClass]
    public class QuantileEnumerableTest
    {
        private readonly IList<QuantileBattery> battery = new List<QuantileBattery>
        {
            new QuantileBattery { Distribution = new List<double> { 0, 2, 3, 5, 6, 8, 9 }, Q0 = 0, Q1 = 2.5, Q2 = 5, Q3 = 7, Q4 = 9 },
            new QuantileBattery { Distribution = new List<double> { 2, 2, 4, 4, 4, 6, 6, 6 }, Q0 = 2, Q1 = 3.5, Q2 = 4, Q3 = 6, Q4 = 6 },
            new QuantileBattery { Distribution = new List<double> { 2, 3 }, Q0 = 2, Q1 = 2.25, Q2 = 2.5, Q3 = 2.75, Q4 = 3 },
            new QuantileBattery { Distribution = new List<double> { -2, -2, 2 }, Q0 = -2, Q1 = -2, Q2 = -2, Q3 = 0, Q4 = 2 }
        };

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Test0PartsDataRaisesArgumentOutOfRangeException()
        {
            battery.First().Distribution.Quantile(0, 1);
        }

        [TestMethod]
        public void TestMedian()
        {
            for (int index = 0; index < battery.Count; index++)
            {
                var test = battery[index];
                double m = test.Distribution.Median();
                Assert.AreEqual(test.Q2, m, 1e-6, $"Median Test {index}");
            }
        }

        [TestMethod]
        public void TestMedianIsQuartile2()
        {
            for (int index = 0; index < battery.Count; index++)
            {
                var test = battery[index];
                double m = test.Distribution.Median();
                double q2 = test.Distribution.Quartile(2);
                Assert.AreEqual(q2, m, 1e-6, $"Median is Q2 Test {index}");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestNullSortedData()
        {
            QuantileEnumerable.Quartile(null, 0);
        }

        [TestMethod]
        public void TestQuartiles()
        {
            for (int index = 0; index < battery.Count; index++)
            {
                var test = battery[index];
                double q0 = test.Distribution.Quartile(0);
                double q1 = test.Distribution.Quartile(1);
                double q2 = test.Distribution.Quartile(2);
                double q3 = test.Distribution.Quartile(3);
                double q4 = test.Distribution.Quartile(4);

                Assert.AreEqual(test.Q0, q0, 1e-6, $"Q0 Test {index}");
                Assert.AreEqual(test.Q1, q1, 1e-6, $"Q1 Test {index}");
                Assert.AreEqual(test.Q2, q2, 1e-6, $"Q2 Test {index}");
                Assert.AreEqual(test.Q3, q3, 1e-6, $"Q3 Test {index}");
                Assert.AreEqual(test.Q4, q4, 1e-6, $"Q4 Test {index}");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestWrongNegativeDataRaisesArgumentOutOfRangeException()
        {
            battery.First().Distribution.Quantile(-2, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestWrongPositiveAfterMaximumIndexDataRaisesArgumentOutOfRangeException()
        {
            battery.First().Distribution.Quantile(5, 4);
        }

        private class QuantileBattery
        {
            public IList<double> Distribution { get; set; }
            public double Q0 { get; set; }
            public double Q1 { get; set; }
            public double Q2 { get; set; }
            public double Q3 { get; set; }
            public double Q4 { get; set; }
        }
    }
}