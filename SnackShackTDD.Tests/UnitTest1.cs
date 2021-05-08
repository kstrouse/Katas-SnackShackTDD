using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace SnackShackTDD.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void InvalidInputForNumberOfSandiches()
        {
            var ioHelper = new TestIOHelper(new[] { "x" });
            var snackShack = new SnackShack(ioHelper);
            snackShack.Run();

            Assert.Collection(ioHelper.Messages,
                item => Assert.Equal("How many sandwiches?", item),
                item => Assert.Equal("You didn't enter a number.", item)
            );
        }

        [Fact]
        public void ZeroSandiches()
        {
            var ioHelper = new TestIOHelper(new[] { "0" });
            var snackShack = new SnackShack(ioHelper);
            snackShack.Run();

            Assert.Collection(ioHelper.Messages,
                item => Assert.Equal("How many sandwiches?", item),
                item => Assert.Equal("You didn't order any sandwiches.", item)
            );
        }

        [Fact]
        public void OneSandwich()
        {
            var ioHelper = new TestIOHelper(new[] { "1" });
            var snackShack = new SnackShack(ioHelper);
            snackShack.Run();

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
            var ioHelper = new TestIOHelper(new[] { "2" });
            var snackShack = new SnackShack(ioHelper);
            snackShack.Run();

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
            var ioHelper = new TestIOHelper(new[] { "4" });
            var snackShack = new SnackShack(ioHelper);
            snackShack.Run();

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
    }

    public class TestIOHelper : IIOHelper
    {
        private readonly IEnumerator<string> input;
        public List<string> Messages = new();

        public TestIOHelper(IEnumerable<string> input)
        {
            this.input = input.GetEnumerator(); ;
        }

        public string ReadLine()
        {
            if (input.MoveNext())
                return input.Current;
            return "";
        }
        public void WriteLine(string message)
        {
            Messages.Add(message);
        }
    }
}
