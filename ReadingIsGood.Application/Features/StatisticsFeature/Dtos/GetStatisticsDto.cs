using ReadingIsGood.Core.Persistance.Repositories.Paging;

namespace ReadingIsGood.Application.Features.StatisticsFeature.Dtos
{
    public class GetStatisticsDto : BasePageableModel
    {
        public ICollection<StatisticsDto>? Items { get; set; }
    }
}
