using Moq;
using Xunit;

namespace XUnitTesting;

public interface IFooService
{
    int Foo();
}

public class Dependency
{
    public virtual int ConfiguredValue => 3;
}

public class FooService : IFooService
{
    private readonly Dependency _dependency;

    public FooService(Dependency dependency)
    {
        _dependency = dependency;
    }
        
    public int Foo()
    {
        return _dependency.ConfiguredValue;
    }
}

public class VirtualFooService : IFooService
{
    public virtual int Foo()
    {
        return 1;
    }
}

public class MockTesting
{
    public class VirtualTesting
    {
        public class WhenSubstitutingValues
        {
            [Fact]
            public void ShouldReturnExpectedValue()
            {
                // arrange
                var sut = new Mock<VirtualFooService>();
                // act
                sut.Setup(s => s.Foo()).Returns(3);
                // assert
                Assert.Equal(3, sut.Object.Foo());
            }
        }

        public class WhenNotSubstitutingValues
        {
            [Fact]
            public void ShouldReturnExpectedValue()
            {
                // arrange
                var sut = new Mock<VirtualFooService>();
                // act
                // assert
                Assert.Equal(0, sut.Object.Foo());
            }
        }
    }

    public class InterfaceTesting
    {
        [Fact]
        public void ShouldReturnExpectedValue()
        {
            // arrange
            var sut = new Mock<IFooService>();
            // act
            sut.Setup(s => s.Foo()).Returns(3);
            // assert
            Assert.Equal(3, sut.Object.Foo());
        }
    }

    public class ConcreteTesting
    {
        [Fact]
        public void ShouldReturnExpectedValue()
        {
            // arrange
            var sut = new Mock<FooService>(new Dependency());
            // act
            // sut.Setup(s => s.Foo()).Returns(3);
            // assert
            Assert.Equal(3, sut.Object.Foo());
        }
    }

    public class WhenMockingClassesWithDependencies
    {
        [Fact]
        public void ShouldReturnExpectedReturnValue()
        {
            // arrange
            var dependencyMock = new Mock<Dependency>();
            dependencyMock.Setup(s => s.ConfiguredValue).Returns(5);
            var sut = new Mock<FooService>(dependencyMock.Object);
            // act
            // assert
            Assert.Equal(5, sut.Object.Foo());
        }
    }
}