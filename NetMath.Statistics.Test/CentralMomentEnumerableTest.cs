using Microsoft.VisualStudio.TestTools.UnitTesting;
using NetMath.Statistics.Moment;
using NetMath.Statistics.Variance;
using System.Collections.Generic;
using System.Linq;

namespace NetMath.Statistics.Test
{
    [TestClass]
    public class CentralMomentEnumerableTest
    {
        [TestMethod]
        public void TestBias()
        {
            var distribution = CreateDistribution();
            double γ1 = distribution.Bias();
            Assert.AreNotEqual(double.NaN, γ1);
            Assert.AreNotEqual(double.NegativeInfinity, γ1);
            Assert.AreNotEqual(double.PositiveInfinity, γ1);
        }

        [TestMethod]
        public void TestCentralMomentAboutMeanR1Equals0()
        {
            var distribution = CreateDistribution();
            double μ1 = distribution.CentralMomentAboutMean(1);
            Assert.AreEqual(0, μ1, 1e-12);
        }

        [TestMethod]
        public void TestCentralMomentAboutMeanR2EqualsVariance()
        {
            var distribution = CreateDistribution();
            double variance = distribution.Variance();
            double μ2 = distribution.CentralMomentAboutMean(2);
            Assert.AreEqual(variance, μ2, 1e-12);
        }

        [TestMethod]
        public void TestCentralMomentR1EqualsArithmeticMean()
        {
            var distribution = CreateDistribution();
            double arithmeticMean = distribution.Average();
            double μ1 = distribution.CentralMoment(1);
            Assert.AreEqual(arithmeticMean, μ1);
        }

        [TestMethod]
        public void TestCentralMomentR2PropertyVariance()
        {
            var distribution = CreateDistribution();
            double variance = distribution.Variance();
            double m1 = distribution.CentralMoment(1);
            double m2 = distribution.CentralMoment(2);
            Assert.AreEqual(variance, m2 - m1 * m1);
        }

        [TestMethod]
        public void TestCurtosis()
        {
            var distribution = CreateDistribution();
            double γ2 = distribution.Curtosis();
            Assert.AreNotEqual(double.NaN, γ2);
            Assert.AreNotEqual(double.NegativeInfinity, γ2);
            Assert.AreNotEqual(double.PositiveInfinity, γ2);
        }

        private static IList<double> CreateDistribution()
        {
            return new List<double> { 0, 2, 2, 3, 5, 6, 6, 8, 9 };
        }
    }
}