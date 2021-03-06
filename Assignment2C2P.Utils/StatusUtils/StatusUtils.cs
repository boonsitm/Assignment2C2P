﻿using System;

namespace Assignment2C2P.Utils.StatusUtils
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
                _ => throw new Exception($"Transaction status[{status}] cannot be mapped in CSV."),
            };
        }

        public static string GetXmlStatusId(string status)
        {
            return status switch
            {
                "approved" => "A",
                "rejected" => "R",
                "done" => "D",
                _ => throw new Exception($"Transaction status[{status}] cannot be mapped in XML."),
            };
        }
    }
}
