using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Models
{
    public class CreditModel
    {
        public string AccountName { get; set; }
        public string Code { get; set; }
        public string Currency { get; set; }
        public string Narrative { get; set; }
        public string ExchangeRate { get; set; }
        public string Amount { get; set; }
        public string AmountDescription { get; set; }
        public string Signature { get; set; }
        public int TransID { get; set; }
    }
}
