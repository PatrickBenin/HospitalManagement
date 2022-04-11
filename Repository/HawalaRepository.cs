using AMS.Context;
using AMS.Models;
using AMS.Repository_Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Repository
{
    public class HawalaRepository : IHawalaRepository
    {
        public IConfiguration _Configuration;
        private readonly DapperContext _context;


        public HawalaRepository(IConfiguration Configuration, DapperContext context)
        {
            _Configuration = Configuration;
            _context = context;
        }
        public async Task<int> SaveHawala(HawalaModel hawalaModel)
        {
            using (var con = _context.CreateConnection())
            {
                var param = new DynamicParameters();

                param.Add("@Hawalano", hawalaModel.HawalaNumber);
                param.Add("@Type", hawalaModel.HawalaType);
                param.Add("@SenderAccount", hawalaModel.SenderAccount);
                param.Add("@SenderName", hawalaModel.SenderName);
                param.Add("@SenderFName", hawalaModel.ReceiverFather);
                param.Add("@ReceiverName", hawalaModel.ReceiverName);
                param.Add("@ReceiverFatherName", hawalaModel.ReceiverFather);
                param.Add("@RTaskiraNo", hawalaModel.TazkiraNo);
                param.Add("@CurrencyID", hawalaModel.Currency);
                param.Add("@ExchangeRate", 1);
                param.Add("@Amount", hawalaModel.Amount);
                param.Add("@Description", hawalaModel.Description);
                param.Add("@UserCreated", 1);

                var _saveHawala = con.Execute("[prInsertHawalaDetails]", param: param, commandType: CommandType.StoredProcedure);

                return _saveHawala;
            }
        }

        public async Task<List<HawalaModel>> GetHawalaDetails()
        {
            using (var con = _context.CreateConnection())
            {

                var _listGetHawala = con.Query<HawalaModel>("prGetHawalaDetails", commandType: CommandType.StoredProcedure).ToList();

                return _listGetHawala;
            }
        }

        
    }
}
