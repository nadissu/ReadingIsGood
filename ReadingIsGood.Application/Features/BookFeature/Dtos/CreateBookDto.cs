using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.Application.Features.BookFeature.Dtos
{
    public class CreateBookDto
    {
        public string Name{get; set; }
        public decimal Price { get; set; }
        public string Author { get; set; }
        public int Stock { get; set; }
    }
}
