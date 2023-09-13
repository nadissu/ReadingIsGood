using ReadingIsGood.Application.Features.OrderFeature.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.Application.Features.StatisticsFeature.Dtos
{
    public class StatisticsDto
    {
        public string Month { get; set; }
        public int TotalOrderCount { get; set; }
        public int TotalBookCount { get; set; }
        public decimal TotalPurchasedAmount { get; set; }
    }
}
