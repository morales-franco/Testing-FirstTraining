using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testing.Essential.Core.Models;

namespace Testing.Essential.Core.Test
{
    [TestClass]
    public class AssertClassTest
    {
        #region AreEqual/AreNotEqual Tests
        [TestMethod]
        [Owner("FM")]
        public void AreEqualsTest()
        {
            string name1 = "Franco";
            string name2 = "Franco";

            Assert.AreEqual(name1, name2);
        }

        [TestMethod]
        [Owner("FM")]
        [ExpectedException(typeof(AssertFailedException))]
        public void AreEqualsCaseSensitiveTest()
        {
            string name1 = "Franco";
            string name2 = "franco";

            //case sensitive: true
            //Assert.AreEqual(name1, name2, true);
            Assert.AreEqual(name1, name2, false);
        }

        [TestMethod]
        [Owner("FM")]
        public void AreNotEqualsTest()
        {
            string name1 = "Franco";
            string name2 = "Fernando";

            Assert.AreNotEqual(name1, name2);
        }

        #endregion

        #region AreSame/AreNotSame Tests

        [TestMethod]
        [Owner("FM")]
        public void AreSameTest()
        {
            var object1 = new FileProcess();
            var object2 = object1;
            Assert.AreSame(object1, object2);
        }

        [TestMethod]
        [Owner("FM")]
        public void AreNotSameTest()
        {
            var object1 = new FileProcess();
            var object2 = new FileProcess();
            Assert.AreNotSame(object1, object2);
        }

        #endregion

        #region IsInstanceOfType Test

        [TestMethod]
        [Owner("FM")]
        public void IsInstanceOfTypeTest()
        {
            PersonManager personManager = new PersonManager();
            Person person = personManager.CreatePerson("Franco", "Morales", true);

            //I'm expected an object of type Supervisor.
            Assert.IsInstanceOfType(person, typeof(Supervisor));
        }

        #endregion

        #region IsNull Test

        [TestMethod]
        [Owner("FM")]
        public void IsNullTest()
        {
            PersonManager personManager = new PersonManager();
            Person person = personManager.CreatePerson("", "Morales", true);

            Assert.IsNull(person);
        }

        #endregion

    }
}
