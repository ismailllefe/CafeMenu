using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Web;
using System.Xml;

namespace CafeMenu.Helpers
{
    public static class CurrencyHelper
    {
        public static decimal GetCurreny(DateTime date)
        {
            var currencyRate = 0M;
            var currencyUrl = "https://www.tcmb.gov.tr/kurlar/";
            var monthYear = date.ToString("yyyyMM");
            var todayMonthYear = date.ToString("ddMMyyyy");
            string exchangeRate = $"{currencyUrl}{monthYear}/{todayMonthYear}.xml";
            var xmlDoc = new XmlDocument();

            try
            {
                xmlDoc.Load(exchangeRate);
                string getDolar = xmlDoc.SelectSingleNode(string.Format("Tarih_Date/Currency[@Kod='{0}']/{1}", "USD", "ForexBuying")).InnerText;
                currencyRate = Convert.ToDecimal(getDolar, CultureInfo.InvariantCulture);
            }
            catch (Exception ex)
            {
                // log yazılacak
            }
            return Math.Round(currencyRate, 2);
        }
    }
}