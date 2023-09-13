using AutoMapper;
using MediatR;
using ReadingIsGood.Application.Features.BookFeature.Dtos;
using ReadingIsGood.Application.Services.Repositories;
using ReadingIsGood.Domain.Entities;

namespace ReadingIsGood.Application.Features.BookFeature.Command
{
    public class UpdateBookCommand : IRequest<UpdateBookDto>
    {
        public int Id { get; set; }
        public UpdateBookDto updateBookDto { get; set; }
        public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, UpdateBookDto>
        {
            private readonly IBookRepository _bookRepository;
            private readonly IMapper _mapper;

            public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
            {
                _bookRepository = bookRepository;
                _mapper = mapper;
            }

            public async Task<UpdateBookDto> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
            {

                var book = await _bookRepository.GetAsync(x => x.Id==request.Id);
                book.Name = request.updateBookDto.Name;
                book.Author = request.updateBookDto.Author;
                book.Price = request.updateBookDto.Price;
                book.Stock = request.updateBookDto.Stock;
                Book updatedBook = await _bookRepository.UpdateAsync(book);
                UpdateBookDto updatedBookDto = _mapper.Map<UpdateBookDto>(updatedBook);
                return updatedBookDto;
            }

        }

    }
}
