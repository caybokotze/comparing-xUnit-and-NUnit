using Xunit;
// ReSharper disable ClassNeverInstantiated.Global

namespace XUnitTesting;

public class Readability
{
    public class WhenSettingUpTests
    {
        public class YouCanAndShould
        {
            public class MakeUseOfNestedClasses
            {
                [Fact]
                public void ToDescribeYourTest()
                {
                    // arrange
                    // act
                    // assert
                    Assert.Equal(1, 1);
                }
            }
        }
    }
}