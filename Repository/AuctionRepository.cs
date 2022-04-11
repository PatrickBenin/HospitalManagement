using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AMS.Context;
using AMS.Models;
using AMS.Repository_Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace AMS.Repository
{
    public class AuctionRepository : IAuctionRepository
    {

        public IConfiguration _Configuration;
        private readonly DapperContext _context;
        public AuctionRepository(IConfiguration Configuration, DapperContext context)
        {
            _Configuration = Configuration;
            _context = context;
        }
        public async Task<List<AuctionModel>> GetAuctionDetails()
        {
            using (var con = _context.CreateConnection())
            {
                var _listAuction = con.Query<AuctionModel>("prgetAuctions", commandType: CommandType.StoredProcedure).ToList();

                return _listAuction;
            }
        }

        public async Task<int> SaveAuctions(AuctionModel auctionModel)
        {

            var param = new DynamicParameters();
            param.Add("@AuctionID", auctionModel.ID);
            param.Add("@SerialNo", auctionModel.SerialNo);
            param.Add("@USDAmount", auctionModel.USDAmount);
            param.Add("@ExRate", auctionModel.ExRate);
            param.Add("@AFNAmount", auctionModel.AFNAmount);
            param.Add("@RelatedDocuments", "~/Documents/" + auctionModel.RelatedDocument);
            param.Add("@Description", auctionModel.Description);
            string StoreprocName = "prInsertUpdateAuction";
            
            using (var con = _context.CreateConnection())
            {
                int result = con.Execute(StoreprocName, param: param, commandType: CommandType.StoredProcedure);

                return result;
            }
        }
    }
}

