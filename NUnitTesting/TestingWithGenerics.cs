using NExpect;
using NUnit.Framework;
using static NExpect.Expectations;

namespace NUnitTesting;

[TestFixture]
public class TestingWithGenerics
{
    private class GenericService
    {
        public bool IsEqualOrInherits<T>(object value)
        {
            return value.GetType() == typeof(T) || value.GetType().IsAssignableFrom(typeof(T));
        }
    }
    
    [TestFixture(typeof(Person), typeof(Person))]
    [TestFixture(typeof(Dog), typeof(Dog))]
    [TestFixture(typeof(Animal), typeof(Animal))]
    [TestFixture(typeof(Dog), typeof(Animal))]
    public class WhenValueIsEqualToOrInheritsFromType<T1, T2> where T1 : class, new() where T2 : class, new()
    {
        [Test]
        public void ShouldBeTrue()
        {
            // arrange
            var sut = new GenericService();
            var thing = new T2();
            // act
            var result = sut.IsEqualOrInherits<T1>(thing);
            // assert
            Expect(result).To.Be.True();
        }
    }
}