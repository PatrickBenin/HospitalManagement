using AMS.Context;
using AMS.Models;
using AMS.Repository_Interfaces;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Repository
{
    public class ExchangeRepository:IExchangeRepository
    {
        
        public IConfiguration _Configuration;
        private readonly DapperContext _context;
       
      
        public ExchangeRepository(IConfiguration Configuration, DapperContext context)
        {
            _Configuration = Configuration;
            _context = context;
        }


        public async Task<List<ExchangeModel>> GetExchangeDetails()
        {
            using (var con = _context.CreateConnection())
            {
                var param = new DynamicParameters();

                param.Add("@TransType", "Exchange");
                var _listAccounts = con.Query<ExchangeModel>("[prGetTransaction]",param:param ,commandType: CommandType.StoredProcedure).ToList();

                return _listAccounts;
            }
        }

        public async Task<int> SaveExchange(ExchangeModel exchangeModel)
        {

            var param = new DynamicParameters();

            param.Add("@TransDescription", exchangeModel.TransDescription);
            param.Add("@CurrencyID", exchangeModel.PurchaseCurrency); 
            param.Add("@DAmount", exchangeModel.PurchaseAmount);
            param.Add("@TransType","ExChange");
            param.Add("@INAccountID", exchangeModel.DebitAccount);
            param.Add("@OUTAccountID", exchangeModel.CreditAccount);
            param.Add("@ExRate", exchangeModel.ExRate);
            param.Add("@CAmount", exchangeModel.SellingAmount);
            param.Add("@cCurrencyID", exchangeModel.SellingCurrency);
            param.Add("@UserCreated", 1);
            param.Add("@CTransDescription", exchangeModel.TransDescription);
            param.Add("@ReferenceID", 1);

            using (var con = _context.CreateConnection())
            {
                int result = con.Execute("PrInsertTransaction", param: param, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        
    }
}
