using ReadingIsGood.Application.Features.BookFeature.Dtos;
using ReadingIsGood.Core.Persistance.Repositories.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.Application.Features.BookFeature.Dtos
{
    public class GetBooksDto : BasePageableModel
    {
        public ICollection<ListBookDto> Items { get; set; }
    }
}
