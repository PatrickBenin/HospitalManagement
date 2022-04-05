using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Models
{
    public class LoanModel
    {
        public string Code { get; set; }
        public int LoanId { get; set; }
        public string AccountName { get; set; }
        public string LoanDate { get; set; }
        public string HijriDate  { get; set; }
        public string LoanAmount { get; set; }
        public string ReturnAmount { get; set; }//creditAmount
        public string AmountDesc { get; set; }
        public string Transcription { get; set; }
        public string Balance { get; set; }
        public string Currency { get; set; }//ExchangeAmount
        public string ExchangeCurrency { get; set; }//ExchangeAmount
        
        public string LoanDescription { get; set; }//TransferAccount
        public string ExRate { get; set; }//TransferAccount

        public string LoanType { get; set; }

    }

    

    public class LoanTypeModel
    {
        public int LoanTypeId { get; set; }
        public string LoanType { get; set; }

    }
}
