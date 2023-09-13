using ReadingIsGood.Core.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.Domain.Entities
{
    public class Statistics:EntityBase
    {
        public string Month { get; set; }
        public int TotalOrderCount  { get; set; }
        public int TotalBookCount { get; set; }
        public decimal TotalPurchasedAmount { get; set; }
    }
}
