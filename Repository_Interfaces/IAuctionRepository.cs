using AMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Repository_Interfaces
{
   public interface IAuctionRepository
    {
        public Task<List<AuctionModel>> GetAuctionDetails();
        public Task<int> SaveAuctions(AuctionModel auctionModel);
    }
}
