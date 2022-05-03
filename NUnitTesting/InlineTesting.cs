using System.Linq;
using NUnit.Framework;

namespace NUnitTesting;

[TestFixture]
public class InlineTesting
{
    [TestCase(3, 1, 2)]
    [TestCase(4, 1, 2, 1)]
    [TestCase(5, 1, 2, 1, 1)]
    public void TestingWithInlineData(int sumOf, params int[] numbers)
    {
        var sum = numbers.Sum();
        Assert.AreEqual(sum, sumOf);
    }
}