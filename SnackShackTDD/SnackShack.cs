namespace SnackShackTDD
{
    public class SnackShack
    {
        private const int FiveMintutes = 5 * 60;
        private readonly IIOHelper ioHelper;
        private readonly IOrderEstimator orderEstimator;

        public SnackShack(IIOHelper ioHelper, IOrderEstimator orderEstimator)
        {
            this.ioHelper = ioHelper;
            this.orderEstimator = orderEstimator;
        }

        public void TakeOrder()
        {
            ioHelper.WriteLine("How many sandwiches?");
            var sandwichCountString = ioHelper.ReadLine();

            if (!ValidInput(sandwichCountString, out var sandwichCount)) return;
            if (!HasOrderToMake(sandwichCount)) return;
            if (!CanMakeOrderOnTime(sandwichCount)) return;

            MakeOrder(sandwichCount);
        }

        private bool ValidInput(string sandwichCountString, out int sandwichCount)
        {
            if (int.TryParse(sandwichCountString, out sandwichCount)) return true;

            ioHelper.WriteLine("You didn't enter a number.");
            return false;
        }
        private bool HasOrderToMake(int sandwichCount)
        {
            if (sandwichCount > 0) return true;

            ioHelper.WriteLine("You didn't order any sandwiches.");
            return false;
        }

        private bool CanMakeOrderOnTime(int sandwichCount)
        {
            orderEstimator.AddSandwiches(sandwichCount);
            var secondsToMakeOrder = orderEstimator.GetEstimate();
            if (secondsToMakeOrder > FiveMintutes)
            {
                ioHelper.WriteLine("We're sorry.  Your order will take to long to serve and cannot be accepted.");
                return false;
            }
            return true;
        }

        private void MakeOrder(int sandwichCount)
        {
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

}
