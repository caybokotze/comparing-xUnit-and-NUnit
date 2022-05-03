using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NUnitTesting;

[TestFixture]
public class ParallelProcessing
{
    [Test]
    public async Task WaitOne()
    {
        // arrange

        // act
        // assert
        Console.WriteLine("One is done");
        await Task.Delay(1000);
    }

    [Test]
    public async Task WaitTwo()
    {
        // arrange

        // act
        // assert
        Console.WriteLine("Two is done");
        await Task.Delay(1000);
    }

    [Test]
    public async Task WaitThree()
    {
        // arrange

        // act
        // assert
        Console.WriteLine("Three is done");
        await Task.Delay(1000);
    }
}