using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Models
{
    public class DebitModel
    {
        public string AccountName { get; set; }
        public string Code { get; set; }
        public string Currency { get; set; }
        public string Narrative { get; set; }
        public string ExchangeRate { get; set; }
        public string DebitAmount { get; set; }
        public string AmountDescription { get; set; }

        public int ID { get; set; }

    }
}
