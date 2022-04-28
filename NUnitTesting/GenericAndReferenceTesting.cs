using NExpect;
using NUnit.Framework;

namespace NUnitTesting;

public class GenericServiceVersionTwo
{
    public bool DoesObjectTypeMatchGenericParameter<T>(object value)
    {
        return value.GetType() == typeof(T);
    }
}

public class GenericService<T>
{
    public T GenericProperty { get; set; }
    
    public void SetGenericProperty(T value)
    {
        GenericProperty = value;
    }
}

[TestFixture]
public class GenericAndReferenceTesting
{
    [TestFixture]
    public class FunWithGenerics
    {
        [TestFixture]
        public class WhenTestingGenericParametersOnMethods
        {
            [Test]
            public void IfIsPersonShouldBeTrue()
            {
                // arrange
                var sut = new GenericServiceVersionTwo();
                var person = new Person();
                // act
                var result = sut.DoesObjectTypeMatchGenericParameter<Person>(person);
                // assert
                Expectations.Expect(result).To.Equal(true);
            }
            
            [Test]
            public void IfIsNotPersonShouldBeFalse()
            {
                // arrange
                var sut = new GenericServiceVersionTwo();
                var animal = new Animal();
                // act
                var result = sut.DoesObjectTypeMatchGenericParameter<Person>(animal);
                // assert
                Expectations.Expect(result).To.Equal(false);
            }
            
            [Test]
            public void IfIsAnimalShouldBeTrue()
            {
                // arrange
                var sut = new GenericServiceVersionTwo();
                var animal = new Animal();
                // act
                var result = sut.DoesObjectTypeMatchGenericParameter<Animal>(animal);
                // assert
                Expectations.Expect(result).To.Equal(true);
            }

            [Test]
            public void IfIsNotAnimalShouldBeFalse()
            {
                // arrange
                var sut = new GenericServiceVersionTwo();
                var person = new Person();
                // act
                var result = sut.DoesObjectTypeMatchGenericParameter<Animal>(person);
                // assert
                Expectations.Expect(result).To.Equal(false);
            }
        }

        [TestFixture(typeof(Person))]
        [TestFixture(typeof(Animal))]
        public class AutoMatedVersionOfAbove<T> where T : class, new()
        {
            [Test]
            public void ShouldBeTrue()
            {
                // arrange
                var sut = new GenericServiceVersionTwo();
                var thing = new T();
                // act
                var result = sut.DoesObjectTypeMatchGenericParameter<T>(thing);
                // assert
                Expectations.Expect(result).To.Be.True();
            }
        }
    }
    
    [TestFixture(typeof(Person))]
    public class WhenTestingGenericParametersOnClasses<T> where T : class, new()
    {
        [Test]
        public void ShouldPersistGenericParameter()
        {
            // arrange
            var sut = new GenericService<T>();
            var person = new T();
            // act
            sut.SetGenericProperty(person);
            var result = sut.GenericProperty;
            // assert
            Expectations.Expect(result).To.Deep.Equal(new T());
        }
    }

    [TestFixture]
    public class FunWithReferences
    {
        /*
         * Some Theory about copying stuff:
         * A shallow copy is a point copy of another object in memory (by reference value)
         * A deep copy is a completely new copy of the object in memory (the references differ)
         */
        
        [TestFixture]
        public class WhenCreatingNewInstancesOfThings
        {
            [Test]
            public void OneInstanceShouldNotEqualAnother()
            {
                // arrange
                const string name = "John";
                var person1 = new Person
                {
                    Name = name
                };
                var person2 = new Person
                {
                    Name = name
                };
                // act
                // assert
                Expectations.Expect(person1).To.Not.Equal(person2);
            }

            [Test]
            public void OneInstanceShouldDeepEqualAnother()
            {
                // arrange
                const string name = "John";
                var person1 = new Person
                {
                    Name = name
                };
                var person2 = new Person
                {
                    Name = name
                };
                // act
                // assert
                Expectations.Expect(person1).To.Deep.Equal(person2);
            }
        }

        [TestFixture]
        public class WhenCopyingDataFromOneVariableToAnother
        {
            [Test]
            public void ReferenceValueShouldBeCopied()
            {
                // arrange
                var person = new Person
                {
                    Name = "Peter"
                };

                var person2 = person;
                person2.Name = "John";

                // act
                // assert
                Expectations.Expect(person).To.Equal(person2);
                Expectations.Expect(person.Name).To.Equal(person2.Name);
            }
        }
    }
}