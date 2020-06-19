using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment2P2C.Utils.CurrencyUtils.Tests
{
    public class FileUtilsTests
    {
        [Test]
        public void CurrencyUtils_CanGetAllCurrencyCodes()
        {
            Assert.IsTrue(CurrencyUtils.GetAllCurrencyCodes().Any());
        }

        [Test]
        public void CurrencyUtils_IsExist_Should_Return_False()
        {
            Assert.IsFalse(CurrencyUtils.IsExist(new List<string> { "USD", "THB" }, "EUR"));
        }

        [Test]
        public void CurrencyUtils_IsExist_Should_Return_True()
        {
            Assert.IsTrue(CurrencyUtils.IsExist(new List<string> { "USD", "THB" }, "THB"));
        }

        [Test]
        public void CurrencyUtils_CanGetValidCurrencyCode()
        {
            Assert.AreEqual("THB", CurrencyUtils.GetValidCurrencyCode(new List<string> { "USD", "THB" }, "THB"));
        }

        [Test]
        public void CurrencyUtils_GetValidCurrencyCode_Throws_Exception()
        {
            Assert.Throws<Exception>(
                () => CurrencyUtils.GetValidCurrencyCode(new List<string> { "USD", "THB" }, "EUR"));
        }
    }
}