using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Models
{
    public class CurrenciesModel
    {
        public int? CurrencyId { get; set; }
        public string CurrencyType { get; set; }
        public string CurrencySymbol { get; set; }
        public string USDExchangeRate { get; set; }
    }
}
