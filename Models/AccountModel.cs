using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Models
{
    public class AccountModel
    {
        public string Code { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string Currency_Symbol { get; set; }
        public int Currency_Id { get; set; }
        public string aAddress { get; set; }
        public string TaskiraNo { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateofBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string sSignature { get; set; }
        public string Photo { get; set; }

        public string AccountType { get; set; }

    }

    public class AccountTypeModel
    {
        public int AccountTypeId { get; set; }
        public string AccountType { get; set; }

    }
}
