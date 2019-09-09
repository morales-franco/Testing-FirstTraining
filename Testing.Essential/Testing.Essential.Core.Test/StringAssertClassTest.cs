using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing.Essential.Core.Test
{
    [TestClass]
    public class StringAssertClassTest
    {
        [TestMethod]
        [Owner("FM")]
        public void ContainsTest()
        {
            var name1 = "Franco Morales";
            var name2 = "Franco";

            StringAssert.Contains(name1, name2);
        }

        [TestMethod]
        [Owner("FM")]
        public void StartsWithTest()
        {
            var name1 = "Franco Morales";
            var name2 = "Franco";

            StringAssert.StartsWith(name1, name2);
        }

        [TestMethod]
        [Owner("FM")]
        public void IsAllLowerCaseTest()
        {
            Regex regularExpression = new Regex(@"^([^A-Z])+$");
            StringAssert.Matches("all lower case", regularExpression);
        }

        [TestMethod]
        [Owner("FM")]
        public void IsNotAllLowerCaseTest()
        {
            Regex regularExpression = new Regex(@"^([^A-Z])+$");
            StringAssert.DoesNotMatch("All Lower Case", regularExpression);
        }

    }
}
