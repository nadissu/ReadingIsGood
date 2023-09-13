namespace ReadingIsGood.Application.Features.BookFeature.Dtos
{
    public class UpdateBookDto
    {
        public string Name{get; set; }
        public decimal Price { get; set; }
        public string Author { get; set; }
        public int Stock { get; set; }
    }
}
