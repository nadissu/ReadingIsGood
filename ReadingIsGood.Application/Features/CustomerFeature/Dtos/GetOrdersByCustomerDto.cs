using ReadingIsGood.Core.Persistance.Repositories.Paging;

namespace ReadingIsGood.Application.Features.CustomerFeature.Dtos
{
    public class GetOrdersByCustomerDto : BasePageableModel
    {
        public ICollection<ListOrderByCustomerDto>? Items { get; set; }
    }
}
