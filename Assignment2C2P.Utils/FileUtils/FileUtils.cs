using System;
using System.IO;
using System.Linq;

namespace Assignment2C2P.Utils.FileUtils
{
    public static class FileUtils
    {
        private static readonly string[] _supportedTypes = new[] { "csv", "xml" };
        private static readonly long _maxLength = 1048576; // 1 MB

        public static string GetFileExtension(string fileName)
        {
            return Path.GetExtension(fileName).Substring(1).ToLowerInvariant();
        }

        public static bool IsValidFileExtension(string fileExtension)
        {
            return _supportedTypes.Contains(fileExtension);
        }

        public static bool IsValidFileSize(long fileSize)
        {
            return _maxLength > fileSize;
        }
    }
}
