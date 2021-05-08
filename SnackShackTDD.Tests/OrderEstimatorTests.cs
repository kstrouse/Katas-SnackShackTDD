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
        //private readonly OrderEstimator snackShack;

        public OrderEstimatorTests()
        {
            //snackShack = new SnackShack(ioHelper);
        }

        [Fact]
        public void ZeroSandwiches()
        {
            var estimator = new OrderEstimator();
            estimator.AddSandwiches(0);

            Assert.Equal(0, estimator.GetEstimate());
        }

        [Fact]
        public void OneSandwich()
        {
            var estimator = new OrderEstimator();
            estimator.AddSandwiches(1);

            Assert.Equal(90, estimator.GetEstimate());
        }

        [Fact]
        public void TenSandwiches()
        {
            var estimator = new OrderEstimator();
            estimator.AddSandwiches(10);

            Assert.Equal(900, estimator.GetEstimate());
        }
    }
}
