using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnackShackTDD
{
    public class OrderEstimator : IOrderEstimator
    {
        private const int SecondsToMakeASandwich = 90;
        private int sandwichCount;

        public void AddSandwiches(int sandwichCount) => this.sandwichCount = sandwichCount;

        public int GetEstimate()
        {
            return sandwichCount * SecondsToMakeASandwich;
        }
    }
}
