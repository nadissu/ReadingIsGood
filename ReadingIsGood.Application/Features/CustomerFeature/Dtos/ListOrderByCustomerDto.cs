using ReadingIsGood.Domain.Entities;

namespace ReadingIsGood.Application.Features.CustomerFeature.Dtos
{
    public class ListOrderByCustomerDto
    {
        public Book Book { get; set; }
        public int Count { get; set; }
        public decimal TotalPrice { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
