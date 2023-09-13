using ReadingIsGood.Core.Persistance.Repositories.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.Application.Features.CustomerFeature.Dtos
{
    public class GetCustomersDto : BasePageableModel
    {
        public ICollection<ListCustomerDto> Items { get; set; }
    }
}
