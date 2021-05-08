using System;

namespace SnackShackTDD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new SnackShack(new ConsoleIOHelper()).Run();
        }
    }

    public class SnackShack
    {
        private readonly IIOHelper ioHelper;

        public SnackShack(IIOHelper ioHelper)
        {
            this.ioHelper = ioHelper;
        }

        public void Run()
        {
            ioHelper.WriteLine("How many sandwiches?");
            var sandwichCountString = ioHelper.ReadLine();

            if (!int.TryParse(sandwichCountString, out var sandwichCount))
            {
                ioHelper.WriteLine("You didn't enter a number.");
                return;
            }

            if (sandwichCount == 0)
            {
                ioHelper.WriteLine("You didn't order any sandwiches.");
                return;
            }

            int elapsedSeconds = 0;
            ioHelper.WriteLine($"0:00 {sandwichCount} sandwich(es) orders placed, start making sandwich 1");
            elapsedSeconds += 60;
            WriteMessageWithTime(elapsedSeconds, "serve sandwich 1");
            elapsedSeconds += 30;
            for (var sandwichNumber = 2; sandwichNumber <= sandwichCount; sandwichNumber++)
            {
                WriteMessageWithTime(elapsedSeconds, $"make sandwich {sandwichNumber}");
                elapsedSeconds += 60;
                WriteMessageWithTime(elapsedSeconds, $"serve sandwich {sandwichNumber}");
                elapsedSeconds += 30;
            }
            WriteMessageWithTime(elapsedSeconds, "take a well earned break!");
        }

        private void WriteMessageWithTime(int elapsedSeconds, string message)
        {
            var seconds = elapsedSeconds % 60;
            var minutes = elapsedSeconds / 60;
            var formattedTime = $"{minutes:0}:{seconds:00}";
            ioHelper.WriteLine($"{formattedTime} {message}");
        }
    }



    public interface IIOHelper
    {
        void WriteLine(string message);
        string ReadLine();
    }

    public class ConsoleIOHelper : IIOHelper
    {
        public string ReadLine() => Console.ReadLine();
        public void WriteLine(string message) => Console.WriteLine(message);
    }

}
