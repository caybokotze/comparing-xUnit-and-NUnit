using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTesting;

public class XUnitTestingFeatures
{
    public XUnitTestingFeatures()
    {
        ANumber = 5;
    }
    
    public int ANumber { get; set; } = 1;
    
    [Fact]
    public void Fact()
    {
        Assert.Equal(1, 1);
    }

    [Theory]
    [InlineData(3, 1, 2)]
    [InlineData(4, 1, 2, 1)]
    [InlineData(5, 1, 2, 1, 1)]
    public void Repeat(int sumOf, params int[] numbers)
    {
        var sum = numbers.Sum();
        Assert.Equal(sum, sumOf);
    }


    public class Nested
    {
        public class Tests
        {
            [Fact]
            public void ShouldStillWork()
            {
                Assert.Equal(1, 1);
            }
        }
    }

    [Fact]
    public void DemonstrateSideEffects()
    {
        // arrange
        
        // act
        // assert
        Assert.Equal(ANumber, 5);
    }
    
    public class Paralellism
    {
        [Fact]
        public async Task WaitOne()
        {
            // arrange
            // act
            // assert
            Console.WriteLine("One is done");
            await Task.Delay(1000);
        }

        [Fact]
        public async Task WaitTwo()
        {
            // arrange
            
            // act
            // assert
            Console.WriteLine("Two is done");
            await Task.Delay(1000);
        }

        [Fact]
        public async Task WaitThree()
        {
            // arrange
            
            // act
            // assert
            Console.WriteLine("Three is done");
            await Task.Delay(1000);
        }
    }
}