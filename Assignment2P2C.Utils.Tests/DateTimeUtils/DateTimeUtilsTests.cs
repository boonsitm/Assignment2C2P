using NUnit.Framework;
using System;

namespace Assignment2P2C.Utils.DateTimeUtils.Tests
{
    public class DateTimeUtilsTests
    {
        [Test]
        public void DateTimeUtils_CanParseDate()
        {
            Assert.AreEqual(new DateTime(2020, 12, 22), DateTimeUtils.ParseDate("22/12/2020"));
        }

        [Test]
        public void DateTimeUtils_ParseDate_Throws_Exception()
        {
            Assert.Throws<FormatException>(
                () => DateTimeUtils.ParseDate("22/12/20"));
        }

        [TestCase("22/12/2020 00:00:00", "csv")]
        [TestCase("2020-12-22T00:00:00", "xml")]
        public void DateTimeUtils_CanParseDate_With_FileExtension(string dateString, string fileExtension)
        {
            Assert.AreEqual(new DateTime(2020, 12, 22), DateTimeUtils.ParseDate(dateString, fileExtension));
        }

        [Test]
        public void DateTimeUtils_ParseDate_With_FileExtension_Throws_Exception()
        {
            Assert.Throws<FormatException>(
                () => DateTimeUtils.ParseDate("22/12/20", "csv"));
        }

        [Test]
        public void DateTimeUtils_CanParseCsvDate()
        {
            Assert.AreEqual(new DateTime(2020, 12, 22), DateTimeUtils.ParseCsvDate("22/12/2020 00:00:00"));
        }

        [Test]
        public void DateTimeUtils_ParseCsvDate_Throws_Exception()
        {
            Assert.Throws<FormatException>(
                () => DateTimeUtils.ParseCsvDate("22/12/20"));
        }

        [Test]
        public void DateTimeUtils_CanParseXmlDate()
        {
            Assert.AreEqual(new DateTime(2020, 12, 22), DateTimeUtils.ParseXmlDate("2020-12-22T00:00:00"));
        }

        [Test]
        public void DateTimeUtils_ParseXmlDate_Throws_Exception()
        {
            Assert.Throws<FormatException>(
                () => DateTimeUtils.ParseXmlDate("22/12/20"));
        }
    }
}
