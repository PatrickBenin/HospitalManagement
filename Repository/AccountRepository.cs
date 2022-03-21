using AMS.Models;
using AMS.Repository_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using AMS.Context;

namespace AMS.Repository
{
    public class AccountRepository : IAccountRepository
    {
        public IConfiguration _Configuration;
        private readonly DapperContext _context;
        public AccountRepository(IConfiguration Configuration, DapperContext context)
        {
            _Configuration = Configuration;
            _context = context;
        }

        public async Task<List<AccountModel>> GetAccountDetails()
        {
            using (var con = _context.CreateConnection())
            {
                var _listAccounts = con.Query<AccountModel>("prGetAccounts", commandType: CommandType.StoredProcedure).ToList();

                return _listAccounts;
            }
        }

        public async Task<List<AccountTypeModel>> GetAccountTypes()
        {
            using (var con = _context.CreateConnection())
            {
                var _listAccountTypes = con.Query<AccountTypeModel>("prGetAccountType", commandType: CommandType.StoredProcedure).ToList();

                return _listAccountTypes;
            }
        }
        public async Task<List<CurrenciesModel>> GetCurrencies()
        {
            using (var con = _context.CreateConnection())
            {
                var _listCurrencies = con.Query<CurrenciesModel>("prGetCurrency", commandType: CommandType.StoredProcedure).ToList();

                return _listCurrencies;
            }
        }

        public async Task<int> SaveCurrencies(CurrenciesModel currenciesModel)
        {
            var param = new DynamicParameters();
            param.Add("@CurrencyName", currenciesModel.CurrencyType);
            param.Add("@CurrencySymbol", currenciesModel.CurrencySymbol);
            param.Add("@ExRate", currenciesModel.USDExchangeRate);
            string StoreprocName = string.Empty;
            if (currenciesModel.CurrencyId > 0)
            {
                param.Add("@ID", currenciesModel.CurrencyId);
                StoreprocName = "prUpdateCurrency";

            }
            else
            {
                StoreprocName = "prInsertCurrency";
            }
            using (var con = _context.CreateConnection())
            {
                int _listCurrencies = con.Execute(StoreprocName,param:param, commandType: CommandType.StoredProcedure);

                return _listCurrencies;
            }
        }

        public async Task<int> SaveAccount(AccountModel accountModel)
        {
            var param = new DynamicParameters();
            param.Add("@Code", accountModel.Code);
            param.Add("@AccountName", accountModel.AccountName);
            param.Add("@LastName", accountModel.LastName);
            param.Add("@FatherName", accountModel.FatherName);
            param.Add("@Currency_ID", accountModel.Currency_Id);
            param.Add("@aAddress", accountModel.aAddress);
            param.Add("@Photo", accountModel.Photo);
            param.Add("@sSignature", !string.IsNullOrEmpty(accountModel.sSignature)? accountModel.sSignature:string.Empty);
            param.Add("@TaskiraNo", accountModel.TaskiraNo);
            param.Add("@EmailAddress", accountModel.EmailAddress);
            param.Add("@DateofBrith", accountModel.DateofBirth.ToShortDateString());
            param.Add("@PhoneNumber", accountModel.PhoneNumber);
            param.Add("@AccountType", accountModel.AccountType);
            string StoreprocName = string.Empty;
            if (accountModel.AccountId > 0)
            {
                StoreprocName = "prUpdateAccount";
            }
            else
            {
                StoreprocName = "prInsertAcount";
            }
            using (var con = _context.CreateConnection())
            {
                int result = con.Execute(StoreprocName, param: param, commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}
