using NExpect;
using NUnit.Framework;
using static NExpect.Expectations;

namespace NUnitTesting;

[TestFixture]
public class DeepEquality
{
    [TestFixture]
    public class FunWithReferences
    {
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
                Expect(person1).To.Not.Equal(person2);
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
                Expect(person1).To.Deep.Equal(person2);
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
                Expect(person).To.Equal(person2);
                Expect(person.Name).To.Equal(person2.Name);
                Expect(person.Name).To.Equal("John");
            }
        }
    }
}