using NUnit.Framework;

namespace NUnitTesting;

public class Setup
{
    public Setup()
    {
        Number = 2;
    }

    private int Number { get; set; } = 1;
    
    [SetUp]
    public void SetupInitialState()
    {
        Number += 1;
    }

    [Test]
    public void ShouldEqualThree()
    {
        // arrange
        
        // act
        // assert
        Assert.AreEqual(3, Number);
    }

    [Test]
    public void ShouldEqualFour()
    {
        // arrange
        
        // act
        // assert
        Assert.AreEqual(4, Number);
    }
}