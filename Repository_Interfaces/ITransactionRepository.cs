using AMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Repository_Interfaces
{
    public interface ITransactionRepository
    {
        public Task<List<CreditDebitModel>> GetCreditDetails();
        public Task<List<CreditDebitModel>> GetDebitDetails();
        public Task<int> SaveCredit(CreditDebitModel accountModel);
        public Task<int> SaveDebit(CreditDebitModel accountModel);
    }
}
