using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing.Essential.Core.Test
{
    /// <summary>
    /// Assembly Initialize and Cleanup Methods
    /// </summary>
    [TestClass]
    public class CoreTestInitialization
    {
       [AssemblyInitialize]
        public static void AssemblyInitialize(TestContext context)
        {
            context.WriteLine("In the Assembly Initialize Method!");
            //TODO: Create resources needed for your tests.
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            //TODO: Clean up any resources useb by your tests.
        }

    }
}
