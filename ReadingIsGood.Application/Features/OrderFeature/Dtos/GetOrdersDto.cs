using ReadingIsGood.Core.Persistance.Repositories.Paging;

namespace ReadingIsGood.Application.Features.OrderFeature.Dtos
{
    public class GetOrdersDto : BasePageableModel
    {
        public ICollection<OrderDto>? Items { get; set; }
    }
}
