using Shouldly;
using System.Linq;
using MoreLinq;
using Xunit;

namespace MoreLINQ_Test
{
    public class MoreLINQ_Test
    {
        [Theory]
        [InlineData("AAABBCCC","AAA")]
        public void Should_Returns_First_Three_A(string input, string expected)
        {
            input.TakeWhile(c => c == 'A').ShouldBe(expected);
        }

        [Theory]
        [InlineData("AAABBCCC", "AAAB")]
        public void Should_Returns_Until_First_B(string input, string expected)
        {
            input.TakeUntil(c => c != 'A').ShouldBe(expected);
        }
    }
}
