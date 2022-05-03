using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
// ReSharper disable ClassNeverInstantiated.Global

namespace XUnitTesting;

public class XUnitTestingFeatures
{
    public class ParallelTesting
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