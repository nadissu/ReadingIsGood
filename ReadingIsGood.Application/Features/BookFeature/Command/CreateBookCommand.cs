using AutoMapper;
using MediatR;
using ReadingIsGood.Application.Features.BookFeature.Dtos;
using ReadingIsGood.Application.Services.Repositories;
using ReadingIsGood.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.Application.Features.BookFeature.Command
{
    public class CreateBookCommand:IRequest<CreateBookDto>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Author { get; set; }
        public int Stock { get; set; }
        public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, CreateBookDto>
        {
            private readonly IBookRepository _bookRepository;
            private readonly IMapper _mapper;

            public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
            {
                _bookRepository = bookRepository;
                _mapper = mapper;
            }

            public async Task<CreateBookDto> Handle(CreateBookCommand request, CancellationToken cancellationToken)
            {

                Book mappedBook = _mapper.Map<Book>(request);
                Book createdBook = await _bookRepository.AddAsync(mappedBook);
                CreateBookDto createdBookDto = _mapper.Map<CreateBookDto>(createdBook);
                return createdBookDto;
            }

        }

    }
}
