using System;
using System.IO;
using System.Runtime.Intrinsics;
using NExpect;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReceivedExtensions;
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
        public int ConfiguredValue => 3;
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
    
    public class WhenMockingClasses
    {
        [Test]
        public void ShouldReturnExpectedValues()
        {
            // arrange
            var dependencyMock = Substitute.For<Dependency>();
            var sut = Substitute.For<FooService>(dependencyMock);
            // act
            var result = sut.Foo();
            // assert
            Expect(result).To.Equal(3);
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
            Expect(result).To.Equal(2);
        }
    }
    
    public class WhenMockingVirtualClasses
    {
        [Test]
        public void ShouldReturnExpectedValues()
        {
            // arrange
            var sut = Substitute.For<VirtualFooService>();
            // act
            var result = sut.Foo();
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
                    // sut.ThrowSomeException().Throws<FileNotFoundException>();
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
                    // sut.ThrowSomeException().Throws<FileNotFoundException>();
                    // act
                    // assert
                    Expect(() => sut.ThrowSomeException()).To.Throw<SystemException>();
                }
            }
        }
    }
}