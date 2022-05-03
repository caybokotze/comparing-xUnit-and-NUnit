using Xunit;
using XUnitTesting.TestingModels;
using XUnitTesting.Utils;

namespace XUnitTesting;

public class DependencyResolutionTests
{
    public class WhenResolvingDependencies
    {
        public class Singletons : TestFixtureRequiringResolver
        {
            [Fact]
            public void DogShouldResolveAsSingleton()
            {
                // arrange
                var person1 = Resolve<Dog>();
                var person2 = Resolve<Dog>();
                // act
                // assert
                Assert.Equal(person1, person2);
                Assert.NotNull(person1);
                Assert.NotNull(person2);
            }
            
            [Fact]
            public void PersonShouldResolveAsSingleton()
            {
                // arrange
                var person1 = Resolve<Person>();
                var person2 = Resolve<Person>();
                // act
                // assert
                Assert.Equal(person1, person2);
                Assert.NotNull(person1);
                Assert.NotNull(person2);
            }
        }

        public class Transient : TestFixtureRequiringResolver
        {
            [Fact]
            public void ShouldResolveAsTransient()
            {
                // arrange
                var animal1 = Resolve<Animal>();
                var animal2 = Resolve<Animal>();
                // act
                // assert
                Assert.NotEqual(animal1, animal2);
                Assert.NotStrictEqual(animal1, animal2);
                Assert.NotNull(animal1);
                Assert.NotNull(animal2);
            }
        }
    }
    
}