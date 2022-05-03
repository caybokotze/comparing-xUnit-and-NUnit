using System;
using System.Threading;
using System.Threading.Tasks;
using NExpect;
using NUnit.Framework;

namespace NUnitTesting;

[TestFixture]
public class Features
{
    public Features()
    {
        ANumber = 2;
    }
    
    public int ANumber { get; set; } = 1;

    [SetUp]
    public void SetANumberToThree()
    {
        ANumber = 3;
    }
    
    [Test]
    [Repeat(10)]
    public void SideEffects()
    {
        // arrange
        
        // act
        // assert
        Thread.Sleep(100);
        Console.WriteLine("testing...");
        Expectations.Expect(ANumber).To.Equal(3);
    }

    
    
}