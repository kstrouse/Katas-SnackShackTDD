using System;
using System.Collections;
using Xunit;

namespace SnackShackTDD.Tests
{
    public class SnackShackTests
    {
        private const int FiveMinutes = 5 * 60;
        private const int FiveMinutesOneSecond = FiveMinutes + 1;

        private TestIOHelper ioHelper = new();
        private FakeOrderEstimator orderEstimator = new();
        private readonly SnackShack snackShack;

        public SnackShackTests()
        {
            snackShack = new SnackShack(ioHelper, orderEstimator);
        }

        [Fact]
        public void InvalidInputForNumberOfSandiches()
        {
            ioHelper.SetInputQueue("x");
            
            snackShack.TakeOrder();

            Assert.Collection(ioHelper.Messages,
                item => Assert.Equal("How many sandwiches?", item),
                item => Assert.Equal("You didn't enter a number.", item)
            );
        }

        [Fact]
        public void ZeroSandiches()
        {
            ioHelper.SetInputQueue("0");
            
            snackShack.TakeOrder();

            Assert.Collection(ioHelper.Messages,
                item => Assert.Equal("How many sandwiches?", item),
                item => Assert.Equal("You didn't order any sandwiches.", item)
            );
        }

        [Fact]
        public void OneSandwich()
        {
            ioHelper.SetInputQueue("1");
            
            snackShack.TakeOrder();

            Assert.Collection(ioHelper.Messages,
                item => Assert.Equal("How many sandwiches?", item),
                item => Assert.Equal("0:00 1 sandwich(es) orders placed, start making sandwich 1", item),
                item => Assert.Equal("1:00 serve sandwich 1", item),
                item => Assert.Equal("1:30 take a well earned break!", item)
            );
        }

        [Fact]
        public void TwoSandwiches()
        {
            ioHelper.SetInputQueue("2");
            
            snackShack.TakeOrder();

            Assert.Collection(ioHelper.Messages,
                item => Assert.Equal("How many sandwiches?", item),
                item => Assert.Equal("0:00 2 sandwich(es) orders placed, start making sandwich 1", item),
                item => Assert.Equal("1:00 serve sandwich 1", item),
                item => Assert.Equal("1:30 make sandwich 2", item),
                item => Assert.Equal("2:30 serve sandwich 2", item),
                item => Assert.Equal("3:00 take a well earned break!", item)
            );
        }

        [Fact]
        public void FourSandwiches()
        {
            ioHelper.SetInputQueue("4");
            
            snackShack.TakeOrder();

            Assert.Collection(ioHelper.Messages,
                item => Assert.Equal("How many sandwiches?", item),
                item => Assert.Equal("0:00 4 sandwich(es) orders placed, start making sandwich 1", item),
                item => Assert.Equal("1:00 serve sandwich 1", item),
                item => Assert.Equal("1:30 make sandwich 2", item),
                item => Assert.Equal("2:30 serve sandwich 2", item),
                item => Assert.Equal("3:00 make sandwich 3", item),
                item => Assert.Equal("4:00 serve sandwich 3", item),
                item => Assert.Equal("4:30 make sandwich 4", item),
                item => Assert.Equal("5:30 serve sandwich 4", item),
                item => Assert.Equal("6:00 take a well earned break!", item)
            );
        }

        [Fact]
        public void FiveMinuteEstimate()
        {
            orderEstimator.SetEstimateToReturn(FiveMinutes);

            ioHelper.SetInputQueue("1");

            snackShack.TakeOrder();

            Assert.Collection(ioHelper.Messages,
                item => Assert.Equal("How many sandwiches?", item),
                item => Assert.Equal("0:00 1 sandwich(es) orders placed, start making sandwich 1", item),
                item => Assert.Equal("1:00 serve sandwich 1", item),
                item => Assert.Equal("1:30 take a well earned break!", item)
            );
        }
        [Fact]
        public void OverFiveMinuteEstimate()
        {
            ioHelper.SetInputQueue("1");
            orderEstimator.SetEstimateToReturn(FiveMinutesOneSecond);

            snackShack.TakeOrder();

            Assert.Collection(ioHelper.Messages,
                item => Assert.Equal("How many sandwiches?", item),
                item => Assert.Equal("We're sorry.  Your order will take to long to serve and cannot be accepted.", item)
            );
        }
    }

    public class FakeOrderEstimator : IOrderEstimator
    {
        private int secondsToReturn;

        public void AddSandwiches(int sandwichCount) { }
        public int GetEstimate() => secondsToReturn;

        public void SetEstimateToReturn(int secondsToReturn) => this.secondsToReturn = secondsToReturn;
    }
}
