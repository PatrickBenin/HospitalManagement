using AMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Repository_Interfaces
{
    public interface IHawalaRepository
    {
        public Task<List<HawalaModel>> GetHawalaDetails();
        public Task<int> SaveHawala(HawalaModel hawalaModel);
    }
}
