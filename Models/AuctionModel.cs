using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Models
{
    public class AuctionModel
    {
        public int ID { get; set; }
        public int SerialNo { get; set; }
        public decimal USDAmount { get; set; }
        public decimal ExRate { get; set; }
        public decimal AFNAmount { get; set; }
        public IFormFile RelatedDocument { get; set; }
        public string Description { get; set; }
    }
}
