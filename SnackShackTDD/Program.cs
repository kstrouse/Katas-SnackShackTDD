using System;

namespace SnackShackTDD
{
    class Program
    {
        static void Main(string[] args)
        {
            new SnackShack(new ConsoleIOHelper(), new OrderEstimator()).TakeOrder();
        } 
    }
}
