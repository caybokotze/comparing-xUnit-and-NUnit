using System;
using NExpect;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;
using static NExpect.Expectations;

namespace NUnitTesting;

[TestFixture]
public class MockTesting
{
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

    public interface IThrowable
    {
        int ThrowSomeException();
    }
    
    public class ThrowingClass : IThrowable
    {
        public int ThrowSomeException()
        {
            throw new SystemException();
        }
    }
    
    public class VirtualThrowingClass : IThrowable
    {
        public virtual int ThrowSomeException()
        {
            throw new SystemException();
        }
    }

    public class WhenMockingInterfaces
    {
        [Test]
        public void ShouldReturnExpectedValues()
        {
            // arrange
            var dependencyMock = Substitute.For<IFooService>();
            // act
            var result = dependencyMock.Foo();
            // assert
            Expect(result).To.Equal(0);
        }
    }
    
    public class WhenMockingVirtualClasses
    {
        [Test]
        public void ShouldReturnExpectedValues()
        {
            // arrange
            var sut = Substitute.For<VirtualFooService>();
            sut.Foo().Returns(2);
            // act
            var result = sut.Foo();
            var proxyTypeHashCode = sut.Foo().GetHashCode();
            // var actualTypeHashCode = new VirtualFooService().Foo().GetHashCode();
            // var actualTypeHashCode2 = new VirtualFooService().Foo().GetHashCode();
            // assert
            Expect(result).To.Equal(2);
        }
    }

    [TestFixture]
    public class WhenCatchingExpectedThrows
    {
        [TestFixture]
        public class VirtualImplementation
        {
            [TestFixture]
            public class WhenSubstituted
            {
                [Test]
                public void ShouldNotThrow()
                {
                    // arrange
                    var sut = Substitute.For<VirtualThrowingClass>();
                    // act
                    // assert
                    Expect(() => sut.ThrowSomeException()).Not.To.Throw<SystemException>();
                }

                [TestFixture]
                public class WithReturn
                {
                    [Test]
                    public void ShouldThrow()
                    {
                        // arrange
                        var sut = Substitute.For<VirtualThrowingClass>();
                        sut.ThrowSomeException().Throws<SystemException>();
                        // act
                        // assert
                        Expect(() => sut.ThrowSomeException()).To.Throw<SystemException>();
                    }
                }
            }

            public class WhenNonSubstituted
            {
                [Test]
                public void ShouldThrow()
                {
                    // arrange
                    var sut = new VirtualThrowingClass();
                    // act
                    // assert
                    Expect(() => sut.ThrowSomeException()).To.Throw<SystemException>();
                }
            }
        }

        [TestFixture]
        public class ConcreteImplementation
        {
            [TestFixture]
            public class WhenSubstituted
            {
                [Test]
                public void ShouldThrow()
                {
                    // arrange
                    var sut = Substitute.For<ThrowingClass>();
                    // sut.ThrowSomeException().Returns(2);
                    // act
                    // assert
                    Expect(() => sut.ThrowSomeException()).To.Throw<SystemException>();
                }
            }

            [TestFixture]
            public class WhenNotSubstituted
            {
                [Test]
                public void ShouldThrow()
                {
                    // arrange
                    var sut = new ThrowingClass();
                    // act
                    // assert
                    Expect(() => sut.ThrowSomeException()).To.Throw<SystemException>();
                }
            }
        }
    }

    public class WhenMockingClassesWithDependencies
    {
        [Test]
        public void ShouldReturnExpectedValues()
        {
            // arrange
            var dependency = new Dependency();
            var sut = Substitute.For<FooService>(dependency);
            // act
            var result = sut.Foo();
            // assert
            Expect(result).To.Equal(3);
        }

        [Test]
        public void ShouldReturnExpectedReturnValue()
        {
            // arrange
            var dependency = Substitute.For<Dependency>();
            dependency.ConfiguredValue.Returns(5);
            var sut = Substitute.For<FooService>(dependency);
            // act
            var result = sut.Foo();
            // assert
            Expect(result).To.Equal(5);
        }
    }
}