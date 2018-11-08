using JetBrains.Annotations;
using System;
using Xunit;

namespace Resharper_Test
{
    public class ResharperRunner
    {
        [Theory]
        [InlineData("Input exist")]
        [InlineData(null)]
        public void ParameterShouldNotBeNull([NotNull] string input)
        {
            Console.WriteLine(input);
        }
    }
}
