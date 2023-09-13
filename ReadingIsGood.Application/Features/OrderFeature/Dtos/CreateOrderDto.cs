using ReadingIsGood.Application.Features.CustomerFeature.Dtos;
using ReadingIsGood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.Application.Features.OrderFeature.Dtos
{
    public class CreateOrderDto
    {
        public List<Book> Books { get; set; }
        public Customer Customer { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
