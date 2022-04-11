using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.Models
{
    public class HawalaModel
    {
        public int ID { get; set; }
        public int HawalaNumber { get; set; }
        public string HawalaType { get; set; }
        public string SenderAccount { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverFather { get; set; }
        public string Currency { get; set; }
        public string Amount { get; set; }
        public string TazkiraNo { get; set; }
        public string Description { get; set; }
    }
}
