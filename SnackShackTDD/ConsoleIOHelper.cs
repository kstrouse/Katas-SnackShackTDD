using System;

namespace SnackShackTDD
{
    public class ConsoleIOHelper : IIOHelper
    {
        public string ReadLine() => Console.ReadLine();
        public void WriteLine(string message) => Console.WriteLine(message);
    }

}
