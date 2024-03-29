﻿using System;
using System.Configuration;
using System.IO;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Testing.Essential.Core.Test
{
    [TestClass]
    public class FileProcessTest
    {
        private const string BAD_FILE_NAME = @"C:\BadFileName.exe";
        private string _GoodFileName;

        #region Class Initialize and Cleanup

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            context.WriteLine("In the class Initialize.");
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
        }

        #endregion

        #region Test Initialize and Cleanup

        /// <summary>
        /// This method is called in each test method before the test is ran.
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            if(TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                SetGoodFileName();

                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine($"Creating the file { _GoodFileName }");
                }

            }
        }

        /// <summary>
        /// This method is called in each test method after the test was ran.
        /// </summary>
        [TestCleanup]
        public void TestCleanup()
        {
            if (TestContext.TestName.StartsWith("FileNameDoesExist"))
            {
                if (!string.IsNullOrEmpty(_GoodFileName))
                {
                    TestContext.WriteLine($"Deleting the file { _GoodFileName }");
                    File.Delete(_GoodFileName);
                }

            }
        }

        #endregion

        public TestContext TestContext { get; set; }

        [TestMethod]
        [Description("Check to see if a file does exist")]
        [Owner("Franco Morales")]
        [Priority(0)]
        public void FileNameDoesExist()
        {
            //TODO: Ey! I need to write the unit test later!
            //Assert.Inconclusive();

            //Writing Test using AAA
            //Step 1: Arrange

            FileProcess fileProcess = new FileProcess();
            bool fileExists = false;

            File.AppendAllText(_GoodFileName, "Hello world!");

            //Step 2: Act

            fileExists = fileProcess.FileExists(_GoodFileName);

            //Step 3: Assert

            Assert.IsTrue(fileExists);


        }

        [TestMethod]
        public void FileNameDoesExistSimpleMessage()
        {
            FileProcess fileProcess = new FileProcess();
            bool fileExists = false;

            File.AppendAllText(_GoodFileName, "Hello world!");

            //Step 2: Act

            fileExists = fileProcess.FileExists(_GoodFileName);

            //Step 3: Assert

            Assert.IsFalse(fileExists, "File {0} Does NOT Exist.", _GoodFileName);
        }

        [TestMethod]
        [Description("Check to see if a file does NOT exist")]
        [Owner("Dev 2")]
        [TestCategory("NoException")]
        public void FileNameDoesNotExist()
        {
            //Step 1: Arrange

            FileProcess fileProcess = new FileProcess();
            bool fileExists = false;

            //Step 2: Act

            fileExists = fileProcess.FileExists(BAD_FILE_NAME);

            //Step 3: Assert

            Assert.IsFalse(fileExists);
        }

        [TestMethod]
        [Owner("Ninja Dev")]
        [ExpectedException(typeof(ArgumentNullException))]
        [Priority(1)]
        [TestCategory("Exception")]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException()
        {
            FileProcess fileProcess = new FileProcess();
            fileProcess.FileExists(string.Empty);
        }

        [TestMethod]
        [Ignore]
        public void FileNameNullOrEmpty_ThrowsArgumentNullException_UsingTryCatch()
        {
            FileProcess fileProcess = new FileProcess();
            try
            {
                fileProcess.FileExists(string.Empty);
            }
            catch (ArgumentNullException)
            {
                //The test was a success
                return;
            }

            Assert.Fail("Call to FileExists did not throw an ArgumentNullException");

        }

        [TestMethod]
        [Timeout(3000)]
        public void SimulateTimeout()
        {
            Thread.Sleep(4000);
        }


        private void SetGoodFileName()
        {
            _GoodFileName = ConfigurationManager.AppSettings["GoodFileName"];

            if (_GoodFileName.Contains("[AppPath]"))
            {
                _GoodFileName = _GoodFileName.Replace("[AppPath]",
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
            }

        }

    }
}
