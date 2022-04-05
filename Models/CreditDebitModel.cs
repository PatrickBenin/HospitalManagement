using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Models
{
    public class CreditDebitModel
    {
        public string DebitAccount { get; set; }
        public string CreditAccount { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string PurchaseCurrency { get; set; }//credit currency
        public string TransDescription { get; set; }
        public string ExRate { get; set; }
        public string SellingCurrency { get; set; }//debit currency
        public string PurchaseAmount { get; set; }//credit Amount
        public string SellingAmount { get; set; }
        public string AmountDescription { get; set; }
        public string Signature { get; set; }
        public int ID { get; set; }
    }
}
