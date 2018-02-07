using System;
using NetStudy.Core;

namespace NetStudy.InDepth.Spans
{
    public class SpanRunner : IRunner
    {
        public void Run()
        {
            var array = new byte[] { 1, 2, 3, 4, 5 };
            var slice = new Span<byte>(array, start: 2, length: 3);
            for (int i = 0 ; i < slice.Length; i++)
            {
                Console.WriteLine(slice[i]); // prints 3,4,5
            }

            var fullName = "Euijun Han".AsSpan();
            var lastName = fullName.Slice(fullName.IndexOf('H'), 3);

            for (int i = 0; i < lastName.Length; i++)
            {
                Console.Write(lastName[i]); // prints 3,4,5
            }
        }
    }
}
