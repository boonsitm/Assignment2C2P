using NUnit.Framework;

namespace Assignment2C2P.Utils.FileUtils.Tests
{
    public class FileUtilsTests
    {
        [TestCase("filename.xml", "xml")]
        [TestCase("filename.sql", "sql")]
        public void FileUtils_CanGetFileExtension(string fileName, string expected)
        {
            Assert.AreEqual(expected, FileUtils.GetFileExtension(fileName));
        }

        [TestCase("xml", true)]
        [TestCase("sql", false)]
        [TestCase("csv", true)]
        public void FileUtils_IsValidFileExtension(string fileExtension, bool expected)
        {
            Assert.AreEqual(expected, FileUtils.IsValidFileExtension(fileExtension));
        }

        [TestCase((long)100, true)]
        [TestCase((long)1048577, false)]
        public void FileUtils_IsValidFileSize(long fileSize, bool expected)
        {
            Assert.AreEqual(expected, FileUtils.IsValidFileSize(fileSize));
        }
    }
}