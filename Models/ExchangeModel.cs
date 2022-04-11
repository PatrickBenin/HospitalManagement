using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Models
{
    public class ExchangeModel
    {
        public int ID { get; set; }
        public string CreditAccount{get;set;}
        public string PurchaseCurrency { get;set;}
        public string PurchaseAmount { get;set;}
        public string ExRate { get;set;}
        public string DebitAccount { get;set;}
        public string SellingCurrency { get;set;}
        public string SellingAmount { get;set;}

        public string TransDescription { get; set; }


    }
}
