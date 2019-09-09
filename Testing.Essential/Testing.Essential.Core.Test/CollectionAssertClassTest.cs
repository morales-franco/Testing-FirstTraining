using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testing.Essential.Core.Models;

namespace Testing.Essential.Core.Test
{
    [TestClass]
    public class CollectionAssertClassTest
    {

        [TestMethod]
        [Owner("FM")]
        public void AreCollectionEqualFailBecauseNoComparerTest()
        {
            PersonManager personManager = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person() { FirstName = "Franco", LastName = "Morales" });
            peopleExpected.Add(new Person() { FirstName = "Fernando", LastName = "Morales" });
            peopleExpected.Add(new Person() { FirstName = "Matias", LastName = "Zimmerman" });

            peopleActual = personManager.GetPeople();

            //Are equals compare that each object is the same object and in this case, they aren't exactly equal.
            CollectionAssert.AreEqual(peopleExpected, peopleActual);
        }

        [TestMethod]
        [Owner("FM")]
        public void AreCollectionEqualWithComparerTest()
        {
            PersonManager personManager = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleExpected.Add(new Person() { FirstName = "Franco", LastName = "Morales" });
            peopleExpected.Add(new Person() { FirstName = "Fernando", LastName = "Morales" });
            peopleExpected.Add(new Person() { FirstName = "Matias", LastName = "Zimmerman" });

            peopleActual = personManager.GetPeople();

            //Provide your own "Comparer" to determine equality
            CollectionAssert.AreEqual(peopleExpected, peopleActual,
                Comparer<Person>.Create((x, y) =>
                 x.FirstName == y.FirstName &&
                 x.LastName == y.LastName ? 0 : 1));
        }

        [TestMethod]
        [Owner("FM")]
        public void AreCollectionEquivalentTest()
        {
            PersonManager personManager = new PersonManager();
            List<Person> peopleExpected = new List<Person>();
            List<Person> peopleActual = new List<Person>();

            peopleActual = personManager.GetPeople();

            //Add same Person objects to new collection, but in in different order
            peopleExpected.Add(peopleActual[2]);
            peopleExpected.Add(peopleActual[0]);
            peopleExpected.Add(peopleActual[1]);

            //Checks for same objects, but in any order
            CollectionAssert.AreEquivalent(peopleExpected, peopleActual);

        }

        [TestMethod]
        [Owner("FM")]
        public void IsCollectionOfTypeTest()
        {
            PersonManager personManager = new PersonManager();

            List<Person> people = new List<Person>();
            people = personManager.GetSupervisors();

            CollectionAssert.AllItemsAreInstancesOfType(people, typeof(Supervisor));

        }
    }
}
