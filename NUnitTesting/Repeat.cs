using System;
using System.Threading;
using NExpect;
using NUnit.Framework;
using static NExpect.Expectations;

namespace NUnitTesting;

[TestFixture]
public class Repeat
{
    [Repeat(10)]
    [Test]
    public void RepeatTest()
    {
        // arrange
        // act
        // assert
        Thread.Sleep(100);
        Console.WriteLine("testing...");
        Expect(1).To.Equal(1);
    }
}