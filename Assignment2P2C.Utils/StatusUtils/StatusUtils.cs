using System;

namespace Assignment2P2C.Utils.StatusUtils
{
    public static class StatusUtils
    {
        public static string GetStatusId(string status, string fileExtension)
        {
            return fileExtension.Equals("csv") ? GetCsvStatusId(status) : GetXmlStatusId(status);
        }

        public static string GetCsvStatusId(string status)
        {
            return status switch
            {
                "approved" => "A",
                "failed" => "R",
                "finished" => "D",
                _ => throw new Exception(string.Format("Transaction status[{0}] cannot be mapped in CSV.", status)),
            };
        }

        public static string GetXmlStatusId(string status)
        {
            return status switch
            {
                "approved" => "A",
                "rejected" => "R",
                "done" => "D",
                _ => throw new Exception(string.Format("Transaction status[{0}] cannot be mapped in XML.", status)),
            };
        }
    }
}
