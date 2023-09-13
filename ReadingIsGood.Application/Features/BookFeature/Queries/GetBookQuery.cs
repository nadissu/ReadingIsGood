using AutoMapper;
using MediatR;
using ReadingIsGood.Application.Features.BookFeature.Dtos;
using ReadingIsGood.Application.Services.Repositories;
using ReadingIsGood.Core.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingIsGood.Application.Features.BookFeature.Queries
{
    public class GetBookQuery : IRequest<GetBooksDto>
    {
        public PageRequest PageRequest { get; set; }
        public class GetBookQueryHandler : IRequestHandler<GetBookQuery, GetBooksDto>
        {
            IBookRepository _bookRepository;
            private readonly IMapper _mapper;

            public GetBookQueryHandler(IBookRepository bookRepository, IMapper mapper)
            {
                _bookRepository = bookRepository;
                _mapper = mapper;
            }

            public async Task<GetBooksDto> Handle(GetBookQuery request, CancellationToken cancellationToken)
            {
                var bookList = await _bookRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                var mapBook = _mapper.Map<GetBooksDto>(bookList);
                return mapBook;
            }
        }
    }
}
