using AMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Repository_Interfaces
{
    public interface IAccountRepository
    {
        public  Task<List<AccountModel>> GetAccountDetails();
        public Task<List<CurrenciesModel>> GetCurrencies();
        public Task<int> SaveCurrencies(CurrenciesModel currenciesModel);
        public Task<int> SaveAccount(AccountModel accountModel);
        public Task<List<AccountTypeModel>> GetAccountTypes();
        public Task<AccountModel> GetAccountDetailbyCode(int accountId);


    }
}
