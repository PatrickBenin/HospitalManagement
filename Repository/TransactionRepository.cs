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
    public class TransactionRepository:ITransactionRepository
    {
        public IConfiguration _Configuration;
        private readonly DapperContext _context;
        public TransactionRepository(IConfiguration Configuration, DapperContext context)
        {
            _Configuration = Configuration;
            _context = context;
        }

    


        public async Task<List<CreditDebitModel>> GetCreditDetails()
        {
            var param = new DynamicParameters();
            param.Add("@TransType", "Credit");
            using (var con = _context.CreateConnection())
            {
                var listcredit = con.Query<CreditDebitModel>("prGetTransaction", param: param, commandType: CommandType.StoredProcedure).ToList();

                return listcredit;
            }
        }

        public async Task<List<CreditDebitModel>> GetDebitDetails()
        {
            var param = new DynamicParameters();
            param.Add("@TransType", "Debit");
            using (var con = _context.CreateConnection())
            {
                var _listAccounts = con.Query<CreditDebitModel>("prGetTransaction", param: param, commandType: CommandType.StoredProcedure).ToList();

                return _listAccounts;
            }
        }

        public async Task<int> SaveCredit(CreditDebitModel accountModel)
        {
            var param = new DynamicParameters();
            
            param.Add("@TransDescription", accountModel.TransDescription);
            param.Add("@CurrencyID", accountModel.PurchaseCurrency);
            param.Add("@DAmount", accountModel.PurchaseAmount);
            param.Add("@TransType", "Credit");
            param.Add("@INAccountID", accountModel.CreditAccount);
            param.Add("@OUTAccountID", "CSH001");
            param.Add("@ExRate", accountModel.ExRate);
            param.Add("@CAmount", accountModel.PurchaseAmount);
            param.Add("@CcurrencyID", accountModel.PurchaseCurrency);
            param.Add("@UserCreated", 1);
            param.Add("@CTransDescription", accountModel.TransDescription);
            param.Add("@ReferenceId", null);
            string StoreprocName = string.Empty;
            if (accountModel.ID > 0)
            {
                StoreprocName = "PrUpdateTransaction";
            }
            else
            {
                StoreprocName = "PrInsertTransaction";
            }
            using (var con = _context.CreateConnection())
            {
                int result = con.Execute(StoreprocName, param: param, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<int> SaveDebit(CreditDebitModel accountModel)
        {
            var param = new DynamicParameters();
         
            param.Add("@TransDescription", accountModel.TransDescription);
            param.Add("@CurrencyID", accountModel.SellingCurrency);
            param.Add("@DAmount", accountModel.SellingAmount);
            param.Add("@TransType", "Debit");
            param.Add("@INAccountID", "CSH001");
            param.Add("@OUTAccountID", accountModel.CreditAccount);
            param.Add("@ExRate", accountModel.ExRate);
            param.Add("@CAmount", accountModel.SellingAmount);
            param.Add("@CcurrencyID", accountModel.SellingCurrency);
            param.Add("@UserCreated", 1);
            param.Add("@CTransDescription", accountModel.TransDescription);
            param.Add("@ReferenceId", null);
            string StoreprocName = string.Empty;
            if (accountModel.ID > 0)
            {
                StoreprocName = "PrUpdateTransaction";
            }
            else
            {
                StoreprocName = "PrInsertTransaction";
            }
            using (var con = _context.CreateConnection())
            {
                int result = con.Execute(StoreprocName, param: param, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public List<AccountModel> GetAccountCode(string Prefix)
        {

            
            var result=new List<AccountModel>();
            var param = new DynamicParameters();

           
          

            using (var con = _context.CreateConnection())
            {
                  result = con.Query<AccountModel>("prGetAllAccounts",  commandType: CommandType.StoredProcedure).ToList();

                 
            }

            List<AccountModel> Name = (from N in result
                      where N.AccountName.StartsWith(Prefix.ToLower()) 
                        select new AccountModel{ AccountName= N.AccountName }).ToList();

            return Name;


        }

        public async Task<List<LoanModel>> GetLoanDetails()
        {
            var param = new DynamicParameters();

            using (var con = _context.CreateConnection())
            {
                var _listAccounts = con.Query<LoanModel>("prGetLoanTransaction", commandType: CommandType.StoredProcedure).ToList();

                return _listAccounts;
            }
        }

        public async Task<int> SaveLoan(LoanModel accountModel)
        {
            var param = new DynamicParameters();

            param.Add("@TransDescription", accountModel.LoanDescription);
            param.Add("@CurrencyID", accountModel.Currency);
            param.Add("@DAmount", accountModel.ReturnAmount);
            if (accountModel.LoanType == "Loan")
            {
                param.Add("@INAccountID", "CSH001");
                param.Add("@OUTAccountID", accountModel.AccountName);
            }
            else if(accountModel.LoanType == "Loan")
            {
                param.Add("@INAccountID", accountModel.AccountName);
                param.Add("@OUTAccountID", "CSH001");
            }

            param.Add("@ExRate", accountModel.ExRate);
            param.Add("@CAmount", accountModel.LoanAmount);
            param.Add("@CcurrencyID", accountModel.ExchangeCurrency);
            param.Add("@CTransDescription", accountModel.LoanDescription);
            param.Add("@TransType", "Loan");
            param.Add("@UserCreated", 1);
            param.Add("@ReferenceId", null);
            string StoreprocName = string.Empty;
            if (accountModel.LoanId > 0)
            {
                StoreprocName = "PrUpdateTransaction";
            }
            else
            {
                StoreprocName = "PrInsertTransaction";
            }
            using (var con = _context.CreateConnection())
            {
                int result = con.Execute(StoreprocName, param: param, commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}
