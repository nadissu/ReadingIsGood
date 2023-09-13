using ReadingIsGood.Domain.Entities;

namespace ReadingIsGood.Application.Features.OrderFeature.Dtos
{
    public class OrderDto
    {
        public Book Book { get; set; }
        public Customer Customer { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
