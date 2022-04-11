using AMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Repository_Interfaces
{
   public interface IExchangeRepository
    {
        public Task<List<ExchangeModel>> GetExchangeDetails();
        public Task<int> SaveExchange(ExchangeModel auctionModel);
    }
}
