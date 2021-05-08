using System;

namespace SnackShackTDD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new SnackShack(new ConsoleIOHelper()).TakeOrder();
        }
    }
}
