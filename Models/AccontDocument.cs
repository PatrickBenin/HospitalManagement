using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Models
{
    public class AccontDocument
    {
        public int  Id { get; set; }
        public string Description { get; set; }
        public string AccountName { get; set; }
        public IFormFile  docFile { get; set; }
        public int AccountId { get; set; }
        public DateTime ExpiryDate   { get; set; }
        public string  URL   { get; set; }
    }
}
