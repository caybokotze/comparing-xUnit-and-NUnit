using NExpect;
using NUnit.Framework;
using NUnitTesting.Utils;
using static NExpect.Expectations;

namespace NUnitTesting;

[TestFixture]
public class DependencyResolutionTesting : TestFixtureRequiringResolver
{
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