using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Assignment2P2C.Utils.CurrencyUtils
{
    public static class CurrencyUtils
    {
        public static IList<string> GetAllCurrencyCodes()
        {
            return CultureInfo.GetCultures(CultureTypes.AllCultures)
                              .Select(culture => {
                                  try
                                  {
                                      return new RegionInfo(culture.Name);
                                  }
                                  catch
                                  {
                                      return null;
                                  }
                              })
                              .Where(ri => ri != null)
                              .Select(ri => ri.ISOCurrencySymbol)
                              .Distinct()
                              .ToList();
        }

        public static bool IsExist(IList<string> listCurrencyCodes, string isoCode)
        {
            return listCurrencyCodes.Any(x => x.Equals(isoCode.ToUpperInvariant()));
        }

        public static string GetValidCurrencyCode(IList<string> listCurrencyCodes, string isoCode)
        {
            return IsExist(listCurrencyCodes, isoCode) ? isoCode.ToUpperInvariant() : 
                throw new Exception($"Currency Code[{isoCode}] is invalid");
        }
    }
}
