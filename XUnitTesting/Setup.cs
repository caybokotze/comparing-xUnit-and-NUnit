using Xunit;

namespace XUnitTesting;

public class Setup
{
    public int ANumber { get; } = 1;
    
    public Setup()
    {
        ANumber = 5;
    }

    [Fact]
    public void ShouldBeFive()
    {
        // arrange
        // act
        // assert
        Assert.Equal(ANumber, 5);
    }
}