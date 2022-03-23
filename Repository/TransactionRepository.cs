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


    }
}
