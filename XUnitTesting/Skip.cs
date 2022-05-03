using Xunit;

namespace XUnitTesting;

public class Skip
{
    public class ExplicitTest
    {
        public class OnePlusOne
        {
            [Fact(Skip = "Skipping this test")]
            public void ShouldEqualTwo()
            {
                // arrange
                // act
                // assert
                Assert.Equal(1, 1);
            }
        }
    }
}