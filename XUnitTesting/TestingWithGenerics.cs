using Xunit;
using XUnitTesting.TestingModels;

namespace XUnitTesting;

public class TestingWithGenerics
{
    private class GenericService
    {
        public bool IsEqualOrInherits<T>(object value)
        {
            return value.GetType() == typeof(T) || value.GetType().IsAssignableFrom(typeof(T));
        }
    }
    
    public class WhenValueIsEqualToOrInheritsFromType
    {
        public class ForPersonAndPerson
        {
            [Fact]
            public void ShouldBeTrue()
            {
                // arrange
                var sut = new GenericService();
                var person = new Person();
                // act
                var result = sut.IsEqualOrInherits<Person>(person);
                // assert
                Assert.Equal(true, result);
            }
        }

        public class ForDogAndDog
        {
            [Fact]
            public void ShouldBeTrue()
            {
                // arrange
                var sut = new GenericService();
                var person = new Dog();
                // act
                var result = sut.IsEqualOrInherits<Dog>(person);
                // assert
                Assert.Equal(true, result);
            }
        }

        public class ForAnimalAndAnimal
        {
            [Fact]
            public void ShouldBeTrue()
            {
                // arrange
                var sut = new GenericService();
                var person = new Animal();
                // act
                var result = sut.IsEqualOrInherits<Animal>(person);
                // assert
                Assert.Equal(true, result);
            }
        }

        public class ForDogAndAnimal
        {
            [Fact]
            public void ShouldBeTrue()
            {
                // arrange
                var sut = new GenericService();
                var person = new Animal();
                // act
                var result = sut.IsEqualOrInherits<Dog>(person);
                // assert
                Assert.Equal(true, result);
            }
        }
        
    }
}