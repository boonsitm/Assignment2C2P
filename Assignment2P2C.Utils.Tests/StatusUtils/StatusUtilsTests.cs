using NUnit.Framework;
using System;

namespace Assignment2P2C.Utils.StatusUtils.Tests
{
    public class StatusUtilsTests
    {
        [TestCase("finished", "csv", "D")]
        [TestCase("done", "xml", "D")]
        public void StatusUtils_CanGetStatusId(string status, string extension, string expected)
        {
            Assert.AreEqual(expected, StatusUtils.GetStatusId(status, extension));
        }

        [TestCase("approved", "A")]
        [TestCase("failed", "R")]
        [TestCase("finished", "D")]
        public void StatusUtils_CanGetCsvStatusId(string status, string expected)
        {
            Assert.AreEqual(expected, StatusUtils.GetCsvStatusId(status));
        }

        [Test]
        public void StatusUtils_GetCsvStatusId_Throws_Exception()
        {
            Assert.Throws<Exception>(
                () => StatusUtils.GetCsvStatusId("ABC"));
        }

        [TestCase("approved", "A")]
        [TestCase("rejected", "R")]
        [TestCase("done", "D")]
        public void StatusUtils_CanGetXmlStatusId(string status, string expected)
        {
            Assert.AreEqual(expected, StatusUtils.GetXmlStatusId(status));
        }

        [Test]
        public void StatusUtils_GetXmlStatusId_Throws_Exception()
        {
            Assert.Throws<Exception>(
                () => StatusUtils.GetXmlStatusId("ABC"));
        }
    }
}
