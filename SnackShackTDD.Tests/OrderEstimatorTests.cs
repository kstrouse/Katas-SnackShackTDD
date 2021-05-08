using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Xunit;

namespace SnackShackTDD.Tests
{
    public class OrderEstimatorTests
    {
        private TestIOHelper ioHelper = new();
        private OrderEstimator estimator;

        public OrderEstimatorTests()
        {
            estimator = new OrderEstimator();
        }

        [Fact]
        public void ZeroSandwiches()
        {
            estimator.AddSandwiches(0);

            Assert.Equal(0, estimator.GetEstimate());
        }

        [Fact]
        public void OneSandwich()
        {
            estimator.AddSandwiches(1);

            Assert.Equal(90, estimator.GetEstimate());
        }

        [Fact]
        public void TenSandwiches()
        {
            estimator.AddSandwiches(10);

            Assert.Equal(900, estimator.GetEstimate());
        }
    }
}
