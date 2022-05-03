using NUnit.Framework;
// ReSharper disable ClassNeverInstantiated.Global

namespace NUnitTesting;

[TestFixture]
public class Readability
{
    [TestFixture]
    public class WhenSettingUpTests
    {
        [TestFixture]
        public class YouCanAndShould
        {
            [TestFixture]
            public class MakeUseOfNestedClasses
            {
                [Test]
                public void ToDescribeYourTest()
                {
                    // arrange
                    // act
                    // assert
                    Assert.AreEqual(1, 1);
                }
            }
        }
    }

    [Test]
    public void Given_When_Then()
    {
        // arrange
        
        // act
        // assert
        Assert.AreEqual(1, 1);
    }
}