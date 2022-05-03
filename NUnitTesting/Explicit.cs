using System;
using NUnit.Framework;

namespace NUnitTesting;

[TestFixture]
public class Explicit
{
    [Test]
    [Explicit]
    public void IntegrationTest()
    {
        Console.WriteLine("Integration logic");
    }

    [Test]
    public void UnitTest()
    {
        Console.WriteLine("Normal unit test");
    }
}