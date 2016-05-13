using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetMath.Statistics.Variance;
using System.Collections.Generic;

namespace NetMath.Statistics.Test
{
    [TestClass]
    public class VarianceEnumerableTest
    {
        [TestMethod]
        public void VarianceTableTest()
        {
            var distribution = new List<ValueFrecuencyPair>
            {
                new ValueFrecuencyPair(4, 20),
                new ValueFrecuencyPair(6, 40),
                new ValueFrecuencyPair(8, 44),
                new ValueFrecuencyPair(10, 36),
                new ValueFrecuencyPair(12, 22),
            };

            Assert.AreEqual(6.02, distribution.Variance(), 1e-2);
            Assert.AreEqual(Math.Sqrt(6.02), distribution.StandardDeviation(), 1e-2);
        }
    }
}