using System.Linq;
using Xunit;

namespace XUnitTesting;

public class InlineTesting
{
    [Theory]
    [InlineData(3, 1, 2)]
    [InlineData(4, 1, 2, 1)]
    [InlineData(5, 1, 2, 1, 1)]
    public void TestingWithInlineData(int sumOf, params int[] numbers)
    {
        var sum = numbers.Sum();
        Assert.Equal(sum, sumOf);
    }
}