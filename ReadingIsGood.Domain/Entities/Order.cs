using ReadingIsGood.Core.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ReadingIsGood.Domain.Entities
{
    public class Order:EntityBase
    {
        public int CustomerId { get; set; }
        public int BookId { get; set; }
        [JsonIgnore]
        public Book Book { get; set; }
        [JsonIgnore]
        public Customer Customer { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }

    public enum OrderStatus
    {
        Approved=0,
        Cancelled=1,
        Wait=2
    }
}
