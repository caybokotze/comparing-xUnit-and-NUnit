using NExpect;
using NUnit.Framework;
using static NExpect.Expectations;

namespace NUnitTesting;

public class DependencyResolutionTesting : TestFixtureRequiringResolver
{
    [TestFixture]
    public class WhenResolvingDependencies : TestFixtureRequiringResolver
    {
        [Test]
        public void ShouldResolveAsSingleton()
        {
            // arrange
            var person1 = Resolve<Person>();
            var person2 = Resolve<Person>();
            // act
            // assert
            Expect(person1)
                .To.Equal(person2);
            
            Expect(person1).To.Not.Be.Null();
            Expect(person2).To.Not.Be.Null();
        }

        [Test]
        public void ShouldResolveAsTransient()
        {
            // arrange
            var animal1 = Resolve<Animal>();
            var animal2 = Resolve<Animal>();
            // act
            // assert
            Expect(animal1)
                .To.Not.Equal(animal2);
            Expect(animal1)
                .To.Deep.Equal(animal2);

            Expect(animal1).To.Not.Be.Null();
            Expect(animal2).To.Not.Be.Null();
        }
    }

    [TestFixture(typeof(Person))]
    [TestFixture(typeof(Dog))]
    public class WhenResolvingSingletons<T> : TestFixtureRequiringResolver where T : notnull
    {
        [Test]
        public void ShouldResolveAsSingleton()
        {
            // arrange
            var instance1 = Resolve<T>();
            var instance2 = Resolve<T>();
            // act
            // assert
            
            Expect(instance1)
                .To.Equal(instance2);
            
            Expect(instance1).To.Not.Be.Null();
            Expect(instance2).To.Not.Be.Null();
        }
    }

    [TestFixture(typeof(Animal))]
    public class WhenResolvingTransients<T> : TestFixtureRequiringResolver where T : notnull
    {
        [Test]
        public void ShouldResolveAsTransient()
        {
            // arrange
            var instance1 = Resolve<T>();
            var instance2 = Resolve<T>();
            // act
            // assert
            Expect(instance1)
                .To.Not.Equal(instance2);
            Expect(instance1)
                .To.Deep.Equal(instance2);

            Expect(instance1).To.Not.Be.Null();
            Expect(instance2).To.Not.Be.Null();
        }
    }
}