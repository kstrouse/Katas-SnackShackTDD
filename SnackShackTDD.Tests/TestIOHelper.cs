using System.Collections.Generic;
using System.Linq;

namespace SnackShackTDD.Tests
{
    public class TestIOHelper : IIOHelper
    {
        private IEnumerator<string> input = Enumerable.Empty<string>().GetEnumerator();
        public List<string> Messages = new();

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

        public void SetInputQueue(params string[] input)
        {
            this.input = input.ToList().GetEnumerator();
        }
    }
}
